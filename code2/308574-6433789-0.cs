        routes.MapRoute("Products", "products/{*params}", 
                        new { controller = "Product",  action = "Details", params= "" });
    
    
       public ActionResult Details(string params) 
       {     
               // Split the params with '/' as delimiter. 
               string [] productParams = params.Split('/');
               if(productParams.Lengh > 0)
               {
                 var category = productParams.Length > 0 ? productParams[0]: null;
                 var subCategory = productParams.Length > 1 ? productParams[1]: null;
                 var detailModel //get model information and build return..
                 
                 ViewData.Model = detailModel; 
                 Return View("Details");
               }
               Return View("Error");
               
              //etc.
              
            
              
       }
