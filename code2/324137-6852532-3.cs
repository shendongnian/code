        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString WizardStepLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return WizardStepLabelFor(htmlHelper, expression, null /* htmlAttributes */);
        }
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString WizardStepLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return WizardStepLabelFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes));
        }
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString WizardStepLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var values = metadata.AdditionalValues;
            // build wizard step label
            StringBuilder labelSb = new StringBuilder();
            TagBuilder label = new TagBuilder("h3");
            label.MergeAttributes(htmlAttributes);
            label.InnerHtml = "Step " + values["StepNumber"] + ": " + values["Name"]; 
            labelSb.Append(label.ToString(TagRenderMode.Normal));
            return new MvcHtmlString(labelSb.ToString() + "\r");
        }
