    public static IHtmlString RadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string list)
        {
            string prefix = ExpressionHelper.GetExpressionText(expression);
            if (string.IsNullOrEmpty(prefix))
                prefix = "empty";
            
            // find existing value - if any
            string value = helper.ViewData.Eval(prefix) as string;
            var validationAttributes = helper.GetUnobtrusiveValidationAttributes(prefix);
            string txt = string.Empty;
            
            // create hidden field for error msg/value
            TagBuilder tagHidden = new TagBuilder("input");
            tagHidden.MergeAttribute("type", "hidden");
            tagHidden.MergeAttribute("name", prefix);
            tagHidden.MergeAttribute("value", value);
            tagHidden.MergeAttribute("id", prefix.Replace('.', '_'));
            foreach (KeyValuePair<string, object> pair in validationAttributes)
            {
                tagHidden.MergeAttribute(pair.Key, pair.Value.ToString());
            }
            txt += tagHidden.ToString(TagRenderMode.Normal);
            // prepare to loop through items
            int index = 0;
            var items = helper.ViewData.Eval(list) as IDictionary<string, string>;
            if (items == null)
                throw new NullReferenceException("Cannot find " + list + "in view data");
            
            // create a radiobutton for each item. "Items" is a dictionary where the key contains the radiobutton value and the value contains the Radiobutton text/label
            foreach (var item in items)
            {
                string id = string.Format("{0}_{1}", prefix, index++).Replace('.','_');
                TagBuilder tag = new TagBuilder("input"); 
                tag.MergeAttribute("type", "radio");
                tag.MergeAttribute("name", prefix);
                tag.MergeAttribute("id", id);
                tag.MergeAttribute("value", item.Key);
                if (item.Key == value)
                    tag.MergeAttribute("checked", "true");
                tag.MergeAttribute("onclick", "javascript:" + tagHidden.Attributes["id"] + ".value='" + item.Key + "'");
                txt += tag.ToString(TagRenderMode.Normal);
                txt += item.Value;
            }
            return helper.Raw(txt);
        }
