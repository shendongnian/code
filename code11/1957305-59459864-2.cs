    public class FoodRecipeRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string title = requestContext.RouteData.Values["title"] as string;
    
            var food = database.GetFoodByTitle(title);
    
            if (food != null)
            {
                requestContext.RouteData.Values["controller"] = "Food";
                requestContext.RouteData.Values["action"] = "FoodDetail";
            }
            else
            {
                var recipe = database.GetRecipeByTitle(title);
    
                if (recipe != null)
                {
                    requestContext.RouteData.Values["controller"] = "Recipe";
                    requestContext.RouteData.Values["action"] = "RecipeDetail";
                }
            }
    
            return base.GetHttpHandler(requestContext);
        }
    }
