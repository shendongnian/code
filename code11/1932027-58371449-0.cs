auto = Data.GetString(0);
in which case: this is simply a null database value. Check for that, and handle it:
if (Data.IsDBNull(0))
{ ... do whatever; perhaps just "continue" }
else
{
    auto = Data.IsDNBull(0);
    // and process it, etc
}
But frankly, you're making life hard for yourself here; here's the same thing with a tool like Dapper:
 c#
using (var conn= new SqlConnection("...whatever..."))
{
    // here we're asserting *exactly* zero or one row
    string auto = conn.QuerySingleOrDefault<string>("select id from records");
    if (auto == null)
    { ... do something else? ... }
    else
    {
        var newid= int.Parse(auto);
    }
}
Note: your query could currently return any number of rows; since the code only processes the last value, I suggest that the SQL needs fixing; perhaps `MAX`, `MIN`, or `TOP 1` with an `ORDER BY` clause; i.e. something like `select MAX(id) as [id] from records`. Note, however, that this sounds like a scenario where you should *probably* have used `SCOPE_IDENTITY()` in some query that added or inserted the value. And an `id` should **very rarely** be a `string`.
