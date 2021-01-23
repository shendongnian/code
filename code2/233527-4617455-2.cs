    public static MvcHtmlString DecimalBoxFor<TEntity>(
                this HtmlHelper helper,
                TEntity model,
                Expression<Func<TEntity, Decimal?>> property,
                string formatString)
            {
                decimal? dec = property.Compile().Invoke(model);
    
                // Here you can format value as you wish
                var value = !string.IsNullOrEmpty(formatString) ? 
                                  dec.Value.ToString(formatString) 
                                : dec.Value.ToString();
                var name = ExpressionParseHelper.GetPropertyPath(property);
    
                return helper.TextBox(name, value);
            }
