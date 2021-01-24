     public IHttpActionResult Get()
     {
          var dbProducts = entities.Products.Include(x => x.ProductAmenities).ToList();
          return Ok(PrepProducts(dbProducts));
     }
