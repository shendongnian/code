    var codes = boxes.Select(c => c.Inventory.ProductCode).ToList();
    int placeId = (int)model.PlaceId;
    var products = GeneralContext.Inventory
    .Join(GeneralContext.Products,
        invtry => invtry.ProductId,
        prdct => prdct.ProductId,
       (invtry, prdct) => new { Inventory = invtry, Product = prdct })
    .Where(q =>
        q.Inventory.PlaceId == placeId &&
        q.Inventory.InventoryStatu == (int)Enums.Reason.Stok &&
        q.Product.IsWithRecipe == false &&
        codes.Contains(q.Inventory.ParentProductCode))
    .ToList();
