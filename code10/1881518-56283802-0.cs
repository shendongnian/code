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
