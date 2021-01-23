    routes.MapRoute(
          "Default1",                                   
          "",                           
          new { controller = "PostController", action = "Index", dynamicBlogName = ""} 
    );
    routes.MapRoute(
          "Default2",                                             
          "{dynamicBlogName}",                          
          new { controller = "PostController", action = "Index", dynamicBlogName = ""  } 
    );
    routes.MapRoute(
          "Default3",                                         
          "post/{dynamicPostName}",                           
          new { controller = "PostController", action = "Default", dynamicBlogName = "", dynamicPostName="" }
    );
    routes.MapRoute(
          "Default4",                                            
          "{dynamicBlogName}/post/{dynamicPostName}",            
          new { controller = "PostController", action = "Default", dynamicBlogName = "", dynamicPostName=""  }
    );
