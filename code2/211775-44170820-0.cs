        /// <summary>
        /// The link will be highlighted when it is used to redirect and also be highlighted when any action-controller pair is used specified in the otherActions parameter.
        /// </summary>
        /// <param name="selectedClass">The CSS class that will be applied to the selected link</param>
        /// <param name="otherActions">A list of tuples containing pairs of Action Name and Controller Name respectively</param>
        public static MvcHtmlString NavLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string parentElement, string selectedClass, IEnumerable<Tuple<string, string>> otherActions)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if ((actionName == currentAction && controllerName == currentController) || 
                (otherActions != null && otherActions.Any(pair => pair.Item1 == currentAction && pair.Item2 == currentController)))
            {
                return new MvcHtmlString($"<{parentElement} class=\"{selectedClass}\">{htmlHelper.ActionLink(linkText, actionName, controllerName)}</{parentElement}>");
            }
            return new MvcHtmlString($"<{parentElement}>{htmlHelper.ActionLink(linkText, actionName, controllerName)}</{parentElement}>");
        }
