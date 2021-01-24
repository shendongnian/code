     [HttpGet]
     [Route("api/product/{productName}")]
     public string GetProduct(string productName)
     {
         return "abc";
     }
