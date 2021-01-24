 c#
public class MyTypeHandler : SqlMapper.TypeHandler<MyType>
{
    public override MyType Parse(object value)
    {
        return ...;
    }
    public override void SetValue(System.Data.IDbDataParameter parameter, MyType value)
    {
        parameter.Value = ...;
    }
}
So, the `Parse` method maps one item from the result row to your custom type. The `SetValue` method maps one instance of your custom type to one database parameter. Mapping multiple items of the result row to one object is not part of the possibilities. 
In your shoes, instead of inventing my own property representation, I would serialize `Money` to `JSON` and save that in one column in the table. You could make a custom handler for that.
That could look something like this:
 c#
public class MoneyTypeHandler : SqlMapper.TypeHandler<Money>
{
    public override Money Parse(Type destinationType, object value)
    {
        return JsonConvert.DeserializeObject(value.ToString(), destinationType);
    }
    public override void SetValue(IDbDataParameter parameter, Money value)
    {
        parameter.Value = (value == null) ? (object)DBNull.Value : JsonConvert.SerializeObject(value);
        parameter.DbType = DbType.String;
    }
}
