    public static class GridHelper
    {
        public static string RenderGrid(this HtmlHelper helper, Object routeParams)
        {          
            return helper.CheckBox("foo");
        }
    }
    public static string RenderGrid<TModel, TProperty>(this HtmlHelper helper<TModel>, Expression<Func<TModel, TProperty>> expr, Object routeParams)
    {
        public static string RenderGrid(this HtmlHelper helper, Object routeParams)
        {          
            return helper.CheckBoxFor( expr );
        }
    }
