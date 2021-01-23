     routes.MapRoute(
                   "MyNewRoute",            // Route name
                   "articles/edit/{id}/{name}",       // URL
                   new { controller = "Articles", action = "Edit", id = "" }, // Defaults
                   new[] { "YourApp.UI.Controllers" }                       // Namespaces
                 );
