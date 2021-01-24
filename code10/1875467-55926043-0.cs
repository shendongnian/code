    <img src="@Url.Action("GetImage", new { productId = Model.Id })" />
    [HttpGet] 
    public FileStreamResult GetImage(Guid productId) 
    { 
        using (var dbContext = new DbContext()) 
        { 
            var product = dbContext.Product.FirstOrDefault(x => x.Id == productId); 
            var ms = new MemoryStream(product.Image); 
            return new FileStreamResult(ms, "image/jpeg"); 
        } 
    } 
