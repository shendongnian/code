     [HttpGet]
     [Route("api/product/{productName}")]
     public object GetProduct(string productName)
     {
         return "abc";
     }
