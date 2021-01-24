    public class AssetDto
    {
      public string Name { get;set; }
      public string Id { get; set; }
    }
    
    public static List<AssetDto> GetAssetIdsWithNames()
    {
        using (var db = DbManager.Get())
        {
            var result = db.Assets.SelectMany(i=> new AssetDto { Name = i.AssetName, Id = i.AssetId }).Distinct().ToList();
            return result;
        }
    }
