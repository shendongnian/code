    public class DictionaryModelBinder : IModelBinder
    {          
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");
            string modelName = bindingContext.ModelName;
            IDictionary<string, string> formDictionary = new Dictionary<string, string>();
            Regex dictionaryRegex = new Regex(modelName + @"\[(?<key>.+?)\]", RegexOptions.CultureInvariant);
            foreach (var key in controllerContext.HttpContext.Request.Form.AllKeys.Where(k => k.StartsWith(modelName + "[")))
            {
                Match m = dictionaryRegex.Match(key);
                if (m.Success)
                {
                    formDictionary[m.Groups["key"].Value] = controllerContext.HttpContext.Request.Form[key];
                }
            }
            return formDictionary;
        }
    }
