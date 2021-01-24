public class DynamicTerm
{
    private readonly Dictionary<string, object> store = new Dictionary<string, object>();
    public void Set(string key, object value) => store[key] = value;
    public object this[string key] => store[key];
}
public static void Main()
{
    string body = "Term.SomeProperty == \"foo\"";
    ParameterExpression termExpr = Expression.Parameter(typeof(DynamicTerm), "Term");
    var exp = DynamicExpressionParser.ParseLambda(new[] { termExpr }, typeof(bool), body);
    var compiled = (Func<DynamicTerm, bool>)exp.Compile();
    var term = new DynamicTerm();
    term.Set("SomeProperty", "foo");
    Console.WriteLine(compiled(term));
}
I can't find a way of returning *typed* data (it converts both sides to object): it works with strings however. Perhaps it's a starting point.
