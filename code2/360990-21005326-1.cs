    public abstract class ViewBase<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public string GetTranslation(string key)
        {
            return _rManager.GetString(key);
        }
    
        private ResourceManager _rManager;
        protected ViewBase()
        {
            _rManager = Resources.ResourceManager.GetResourceSet(new CultureInfo(cultureName), true, true);
        }
    
    
    }
