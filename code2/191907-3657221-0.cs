    public static class GridHelper 
    { 
        public static string RenderGrid(this HtmlHelper helper, Object routeParams) 
        {           
            return helper.BeginForm(routeParams); 
        } 
    } 
