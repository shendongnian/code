     public abstract class RequestLifetimeCacheBase
     {
        private readonly HttpContext _requestContext;
        protected RequestLifetimeCacheBase(HttpContext requestContext)
        {
            _requestContext = requestContext;
        }
        protected RequestLifetimeCacheBase(Controller controller)
            : this(controller.HttpContext)
        {
        }
        #region Generic access to cached value-type data
        protected TValue? GetCachedValue<TValue>(string cacheKey)
            where TValue : struct
        {
            var value = _requestContext.Items[cacheKey];
            if (value is TValue)
            {
                return (TValue)value;
            }
            else
            {
                return null;
            }
        }
        protected void SetCachedValue<TValue>(string cacheKey, TValue? value)
            where TValue : struct
        {
            if (value.HasValue)
            {
                _requestContext.Items[cacheKey] = value.Value;
            }
            else
            {
                _requestContext.Items.Remove(cacheKey);
            }
        }
        #endregion
        #region Generic access to cached reference-type data
        protected TObject GetCachedObject<TObject>(string cacheKey)
            where TObject : class
        {
            return _requestContext.Items[cacheKey] as TObject;
        }
        protected void SetCachedObject<TObject>(string cacheKey, TObject value)
            where TObject : class
        {
            if (value != null)
            {
                _requestContext.Items[cacheKey] = value;
            }
            else
            {
                _requestContext.Items.Remove(cacheKey);
            }
        }
        #endregion
    }
