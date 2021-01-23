        public static MvcHtmlString TheDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues, string placeHolder)
        {
            var model = htmlHelper.ViewData.Model;
            var metaData = ModelMetadata .FromLambdaExpression(expression, htmlHelper.ViewData);
            
            var tb = new TagBuilder("select");
            if (listOfValues != null)
            {
                tb.MergeAttribute("id", metaData.PropertyName);
                if (!string.IsNullOrEmpty(placeHolder))
                {
                    var option = new TagBuilder("option");
                    option.MergeAttribute("value", placeHolder);
                    tb.InnerHtml += option.ToString();
                }
                foreach (var item in listOfValues)
                {
                    var option = new TagBuilder("option");
                    option.MergeAttribute("value", item.Value);
                    var textNdata = item.Text.Split('|');
                    option.InnerHtml = textNdata[0];
                    if (textNdata.Length == 2)
                    {
                        option.MergeAttribute("data-name", textNdata[1]);
                    }
                    tb.InnerHtml += option.ToString();
                }
            }
            return MvcHtmlString.Create(tb.ToString());
        }
