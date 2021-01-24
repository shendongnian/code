C#
public static List<(string Name, int Id)> GetAssetWithIds()
{
    using (var db = DbManager.Get())
    {
        var result = db.Assets
            .Select(a => new { a.AssetName, a.AssetId })
            .Distinct().AsEnumerable()
            .Select(a => (a.AssetName, a.AssetId))
            .ToList();
        return result;
    }
}
You will need to add `System.ValueTuple`
