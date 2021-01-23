    public static class EnumDropDownListForHelper
    {
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression
            ) where TModel : class
        {
            return EnumDropDownListFor<TModel, TProperty>(
                                htmlHelper, expression, null, null);
        }
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression, 
                object htmlAttributes
            ) where TModel : class
        {
            return EnumDropDownListFor<TModel, TProperty>(
                                htmlHelper, expression, null, htmlAttributes);
        }
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression, 
                IDictionary<string, object> htmlAttributes
            ) where TModel : class
        {
            return EnumDropDownListFor<TModel, TProperty>(
                                htmlHelper, expression, null, htmlAttributes);
        }
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression, 
                string optionLabel
            ) where TModel : class
        {
            return EnumDropDownListFor<TModel, TProperty>(
                                htmlHelper, expression, optionLabel, null);
        }
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression, 
                string optionLabel, 
                IDictionary<string,object> htmlAttributes
            ) where TModel : class
        {
            string inputName = GetInputName(expression);
            return htmlHelper.DropDownList(
                                inputName, ToSelectList(typeof(TProperty)), 
                                optionLabel, htmlAttributes);
        }
    
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TProperty>> expression, 
                string optionLabel, 
                object htmlAttributes
            ) where TModel : class
        {
            string inputName = GetInputName(expression);
            return htmlHelper.DropDownList(
                                inputName, ToSelectList(typeof(TProperty)), 
                                optionLabel, htmlAttributes);
        }
    
    
        private static string GetInputName<TModel, TProperty>(
                Expression<Func<TModel, TProperty>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.Call)
            {
                MethodCallExpression methodCallExpression 
                                = (MethodCallExpression)expression.Body;
                string name = GetInputName(methodCallExpression);
                return name.Substring(expression.Parameters[0].Name.Length + 1);
    
            }
            return expression.Body.ToString()
                        .Substring(expression.Parameters[0].Name.Length + 1);
        }
    
        private static string GetInputName(MethodCallExpression expression)
        {
            // p => p.Foo.Bar().Baz.ToString() => p.Foo OR throw...
            MethodCallExpression methodCallExpression 
                                = expression.Object as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return GetInputName(methodCallExpression);
            }
            return expression.Object.ToString();
        }
    
    
        private static SelectList ToSelectList(Type enumType)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(item.ToString());
                var attribute = fi.GetCustomAttributes(
                                           typeof(DescriptionAttribute), true)
                                      .FirstOrDefault();
                var title = attribute == null ? item.ToString() 
                                  : ((DescriptionAttribute)attribute).Description;
                var listItem = new SelectListItem
                {
                    Value = item.ToString(),
                    Text = title,
                };
                items.Add(listItem);
            }
    
            return new SelectList(items, "Value", "Text");
        }
    }
