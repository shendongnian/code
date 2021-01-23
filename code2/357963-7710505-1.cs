    public static IHtmlString RadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string list)
        {
            string prefix = ExpressionHelper.GetExpressionText(expression);
            if (string.IsNullOrEmpty(prefix))
                prefix = "empty";
            int index = 0;
            var items = helper.ViewData.Eval(list) as IEnumerable;
            if (items == null)
                throw new NullReferenceException("Cannot find " + list + "in view data");
            var validationAttributes = helper.GetUnobtrusiveValidationAttributes(prefix);
            string txt = string.Empty;
            foreach (var item in items)
            {
                string id = string.Format("{0}_{1}", prefix, index++).Replace('.','_');
                TagBuilder tag = new TagBuilder("input"); 
                tag.MergeAttribute("type", "radio");
                tag.MergeAttribute("name", prefix);
                tag.MergeAttribute("id", id);
                foreach (KeyValuePair<string, object> pair in validationAttributes)
                {
                    tag.MergeAttribute(pair.Key, pair.Value.ToString());
                }
                txt += tag.ToString(TagRenderMode.Normal);
                txt += item;
            }
            return helper.Raw(txt);
        }
