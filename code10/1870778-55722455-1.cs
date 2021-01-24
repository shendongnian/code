    namespace TestMvc
    {
        using Microsoft.AspNetCore.Mvc.Razor;
        using System.Collections.Generic;
    
        public class ComponentViewLocationExpander : IViewLocationExpander
        {
            public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
            {
                // this also feels ugly
                // I could not find another way to detect
                // whether the view name is related to a component
                // but it's somewhat better than adding the path globally
                if (context.ViewName.StartsWith("Components"))
                    return new string[] { "/{0}" + RazorViewEngine.ViewExtension };
                return viewLocations;
            }
            public void PopulateValues(ViewLocationExpanderContext context) {}
        }
    }
