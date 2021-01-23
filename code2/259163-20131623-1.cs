    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    /// <summary>
    /// When the BindAttribute is in use, validation errors only show for values that 
    /// are included or not excluded.
    /// </summary>
    public class ValidateBindableValuesOnlyAttributes : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            var includedProperties = filterContext.ActionDescriptor.GetParameters()
                .SelectMany(o => o.BindingInfo.Include.Select(name => (string.IsNullOrWhiteSpace(o.BindingInfo.Prefix) ? "" : o.BindingInfo.Prefix + ".") + name));
            var excludedProperties = filterContext.ActionDescriptor.GetParameters()
                .SelectMany(o => o.BindingInfo.Exclude.Select(name => (string.IsNullOrWhiteSpace(o.BindingInfo.Prefix) ? "" : o.BindingInfo.Prefix + ".") + name));
            var ignoreTheseProperties = new List<KeyValuePair<string, ModelState>>();
            if (includedProperties.Any())
            {
                ignoreTheseProperties.AddRange(modelState.Where(k => !includedProperties.Any(name => Regex.IsMatch(k.Key, "^" + Regex.Escape(name) + @"(\.|\[|$)"))));
            }
            ignoreTheseProperties.AddRange(modelState.Where(k => excludedProperties.Any(name => Regex.IsMatch(k.Key, "^" + Regex.Escape(name) + @"(\.|\[|$)"))));
            foreach (var item in ignoreTheseProperties)
            {
                item.Value.Errors.Clear();
            }
        }
    }
