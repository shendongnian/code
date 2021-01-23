    public static class ViewDataDictionaryExtensions
    {
        public static ViewDataDictionary<TModel> MergeClasses<TModel>(this ViewDataDictionary<TModel> dict, string classes)
        {
            if (dict.ContainsKey("class"))
                dict["class"] += " " + classes;
            else
                dict.Add("class", classes);
            return dict;
        }
        public static ViewDataDictionary<TModel> MergeStyles<TModel>(this ViewDataDictionary<TModel> dict, string styles)
        {
            if (dict.ContainsKey("style"))
                dict["style"] += "; " + styles;
            else
                dict.Add("style", styles);
            return dict;
        }
    }
