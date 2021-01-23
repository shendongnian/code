    // maps /Admin/Books/ViewBook/{id} to AdminBooksController.BookDetails(id)
    routes.MapRoute(
    	"AdminBooks_ViewBook", // Route name
    	"Admin/Books/ViewBook/{id}", // URL with parameters
    	new { controller = "AdminBooks", action = "BookDetails", id = UrlParameter.Optional } // Parameter defaults
    );
    
    // maps /Admin/Books/{action}/{id} to AdminBooksController.{Action}(id)
    routes.MapRoute(
    	"AdminBooks_Default", // Route name
    	"Admin/Books/{action}/{id}", // URL with parameters
    	new { controller = "AdminBooks", action = "List", id = UrlParameter.Optional } // Parameter defaults
    );
