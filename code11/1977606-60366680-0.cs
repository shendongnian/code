c#
public class MyResultClass
{
    public int year;
    public int conte;
    public int rating;
    public int duree;
}
var results =
    from row in Globals.ds.Tables["Song"].AsEnumerable()
    group row by (row.Field<int>("year"), row.Field<int>("rating")) into grp
    orderby grp.Key
    select new MyResultClass
    {
        year = grp.Key.Item1,
        conte = grp.ToList().Count,
        rating = grp.Key.Item2,
        duree = grp.Sum(r => r.Field<int>("duree"))
    };
I hope I was helpful.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
  [2]: https://stackoverflow.com/a/3982245/12730306
