    if (Request.QueryString.HasKeys()) 
    {
         var values = Request.QueryString.GetValues("emailfield");
         if (values != null)
         {
             var id= Convert.ToInt32(values[0]);
         }
    }
 
