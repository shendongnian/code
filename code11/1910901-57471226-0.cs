    public class LibraryAssetService
    {
      public LibraryAssetService(DataContext context)
      {
         _context = context;
      }
      private readonly DataContext _context;
      public async Task<LibraryAsset> GetAsset(int assetId)
      {
         var asset = await _context.LibraryAssets
            .Include(p => p.Photo)
            .Include(s => s.Author)
            .FirstOrDefaultAsync(x => x.Id == assetId);
         return asset;
      }
    }
