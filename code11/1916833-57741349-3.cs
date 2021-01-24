    public IEnumerable<InventoryAsset> searchInventoryAssets(string query, string category, string market, string column)
    {
        var assets = from inventoryAsset in _context.InventoryAssets 
            join marketCategory in _context.MarketCategories on inventoryAsset.MarketCategory_Identity equals marketCategory.Identity
            join itemCategory in _context.ItemCategories on inventoryAsset.ItemCategory_Identity equals itemCategory.Identity
            select inventoryAsset;
    
        switch (column)
        {
            case "Title":
                assets = from inventoryAsset in assets where inventoryAsset.Title equals query select inventoryAsset;
                break;
            default:
                // throw or whatever suits
                break;
        }
    
        return  assets.ToList();
    }
