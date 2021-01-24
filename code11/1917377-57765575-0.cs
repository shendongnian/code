c#
using (var ctx = new ML_DbEntities())
{
    var data = from item in ctx.ThirdPartyData
               where item.site_id == "MLA" && !IsGapChecked.HasValue
               let PrimaryKey = item.ML_ItemId.Right(item.ML_ItemId.Length - 3) as long
               orderby PrimaryKey
               select PrimaryKey;
    var top10 = data.Take(10);
}
Also, I **strongly** advise against using `ToList`.  It's rarely necessary and it can cause serious performance problems.
