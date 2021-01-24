c#
public void Query_CallFunctionThatTakesInUserDefinedType_FunctionUsesUserDefinedType()
{
    // Arrange
    using (var conn = Db.GetConnection())
    {
        var functionName = "test_function_that_takes_in_udt";
        var expect = CharacterTestData.First();
        // Act
        var result = conn.Query<Character>(functionName,
            new 
            {
                our_hero = new HeroParameter(
                    CharacterTestData.First().FirstName,
                    CharacterTestData.First().LastName
                )
            },
            commandType: CommandType.StoredProcedure
        ).FirstOrDefault();
        // Assert
        Assert.AreEqual(expect, result);
    }
}
**NOTE** There are some refactorings (names for example) in the code above since the original question, however, the body of the PostgreSQL function was unchanged. The most notable refactoring related to this answer is how the connection is created:
c#
public NpgsqlConnection GetConnection()
{
    var connection = new NpgsqlConnection(GetConnectionStringToDatabase());
    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    connection.Open();
    connection.ReloadTypes();
    /*
     * 
     * Ideally, should move this to be handled for _all_ connections like:
     *      NpgsqlConnection.GlobalTypeMapper.MapEnum<SomeEnum>("some_enum_type");
     *      NpgsqlConnection.GlobalTypeMapper.MapComposite<SomeType>("some_composite_type");
     *  
     */
    connection.TypeMapper.MapComposite<Hero>("hero");
    return connection;
}
Supporting HeroParameter
------------------------
c#
public class HeroParameter : ICustomQueryParameter
{
    private readonly Hero _hero;
    public HeroParameter(string firstName, string lastName)
    {
        _hero = new Hero(firstName, lastName);
    }
    public void AddParameter(IDbCommand command, string name)
    {
        var parameter = new NpgsqlParameter
        {
            ParameterName = name,
            Value = _hero,
            DataTypeName = "hero"
        };
        command.Parameters.Add(parameter);
    }
}
Not using `TypeHandlers` proved to be very advantageous in our situation. 
This is due to the finicky nature in which PostgreSQL might use a UDT/composite type when being returned from a function. For example, if the UDT is one of 2 or more columns being returned, PostgreSQL returns the result set with the UDT column in the shape of `(val1, val2)`. However, if the thing being returned is _just_ the UDT, PostgreSQL will expand the UDT's individual properties to individual columns, much like a normal `SELECT` from a table.
For example, consider the following function:
sql
CREATE OR REPLACE FUNCTION example_function()
    RETURNS hero
    LANGUAGE SQL
AS
$$
SELECT ('Peter', 'Parker')::hero as heroes
$$
In this scenario, in order for the `TypeHandler` to work, we need the result to be in the following format:
|-----------------|
|      heroes     |
|-----------------|
| (Peter, Parker) |
|-----------------|
This is because after a call like `conn.Query<Hero>(...)`, Dapper will pass the first column (and only the first) to the `TypeHandler` expecting it to do the necessary conversion. 
However, the output from the above function, `example_function`, will actually return the result in the following expanded format:
|------------|-----------|
| first_name | last_name |
|------------|-----------|
|   Peter    |  Parker   |
|------------|-----------|
This means that the `Type` of `value` that gets passed to the `TypeHandler.Parse()` method is `string` in this example.
However, for functions that return the UDT as one of the columns when 2 or more columns are returned, then the `TypeHandler` works as expected because the single column's value is passed to the `Parse` method. 
Consider this updated function:
sql
CREATE OR REPLACE FUNCTION example_function()
    RETURNS TABLE (year integer, hero hero)
    LANGUAGE SQL
AS
$$
SELECT 1962 AS year, ('Peter', 'Parker')::hero AS hero
$$
Which returns the output in the following format:
|------|-----------------|
| year |      hero       |
|------|-----------------|
| 1962 | (Peter, Parker) |
|------|-----------------|
This is where the original solution below falls short. In that example, I wasn't (yet) using the `Parse` method. However, once I needed to implement that function to support UDTs being _returned_, the `TypeHandler` wouldn't work based on the ways PostgreSQL returns the UDTs as demonstrated above.
----------
ORIGINAL ANSWER
===============
For anyone else that might stumble upon this question, this worked for me, although I'm not terribly happy with it, so I'm open to better solutions to this problem.
Working Integration Test
------------------------
c#
[Test]
public void Query_CallFunctionThatTakesInUserDefinedType_FunctionUsesUserDefinedType()
{
    // Arrange
    using (var conn = new NpgsqlConnection(Db.GetConnectionStringToDatabase()))
    {
        var funcName = "testfuncthattakesinudt";
        var expect = CharacterTestData.First();
        SqlMapper.AddTypeHandler(new HeroTypeHandler());
        conn.Open();
        conn.ReloadTypes();
        conn.TypeMapper.MapComposite<Hero>("hero");
        // Act
        var result = conn.Query<Character>(funcName,
            new
            {
                our_hero = new Hero
                {
                    first_name = CharacterTestData.First().first_name,
                    last_name = CharacterTestData.First().last_name
                }
            },
            commandType: CommandType.StoredProcedure
        ).FirstOrDefault();
        // Assert
        Assert.AreEqual(expect, result);
    }
}
Supporting HeroTypeHandler
--------------------------
c#
internal class HeroTypeHandler : SqlMapper.TypeHandler<Hero>
{
    public override Hero Parse(object value)
    {
        throw new NotImplementedException();
    }
    public override void SetValue(IDbDataParameter parameter, Hero value)
    {
        parameter.Value = value;
    }
}
The fix seemed to be two parts:
1. It was necessary to add a `HeroTypeHandler` and map it via `SqlMapper.AddTypeHandler`.
2. I needed to map my type `Hero` to my PostgreSQL composite type `hero` via `conn.TypeMapper.MapComposite`. However, my gut feeling (so far) is that this is just me fighting my own integration tests, as in a real application it would probably (?) be ideal to register all composite types globally at the start of the application. (Or maybe not due to performance reasons if there is a lot of them?)
What I don't like about this solution though is that my `HeroTypeHandler` doesn't really provide any real value (no pun intended). By simply assigning `value` to `parameter.Value` things worked, which my guess would have been that this is something Dapper would have done for the call, but obviously not. (?) I'd prefer to not need to do that for a lot of composite types if I had a lot of them.
Note that since I'm only concerned with sending this type _to_ a PostgreSQL function, I didn't find it necessary to implement the `Parse` method, hence the `NotImplementedException`. YMMV
Also, due to some refactoring since I posted the original question, there are some other minor differences. However, they were not related to the overall fix detailed above.
