      public IHttpActionResult GetProduct(string name)
        {
            var product = products.FirstOrDefault((p) => p.Name == name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
