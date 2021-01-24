    /// <summary>
    /// Assign the culture to every LocalizedString from the response.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class SetCultureToLocalizedStringsAttribute : ActionFilterAttribute
    {
        #region Methods
        /// <summary>
        /// Occurs after the action method is invoked
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var content = actionExecutedContext.Response.Content != null ? await actionExecutedContext.Response.Content.ReadAsAsync<object>(cancellationToken) : null;
            AssignCultureOfLocalizedStringProperties(
                content,
                typeof(LocalizedString)
                    .GetProperties().First(x => x.PropertyType == typeof(CultureInfo)),
                Thread.CurrentThread.CurrentCulture);
        }
        private static void AssignCultureOfLocalizedStringProperties(object obj, PropertyInfo cultureProperty, CultureInfo culture)
        {
            if (obj == null || obj.GetType().IsValueType())
            {
                return;
            }
            if (obj.GetType() == typeof(LocalizedString))
            {
                cultureProperty.SetValue(obj, culture);
                return;
            }
            var currentProperties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in currentProperties)
            {
                var propValue = property.GetValue(obj);
                if (property.PropertyType.IsValueType())
                {
                    continue;
                }
                if (propValue is IEnumerable elems)
                {
                    foreach (var item in elems)
                    {
                        AssignCultureOfLocalizedStringProperties(item, cultureProperty, culture);
                    }
                }
                else
                {
                    AssignCultureOfLocalizedStringProperties(propValue, cultureProperty, culture);
                }
            }
        }
        #endregion
    }
