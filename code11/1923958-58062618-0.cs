    public ContentApiController(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }
    
        public IHttpActionResult Get(int id, string culture)
        {
            _variationContextAccessor.VariationContext = new VariationContext(culture);
            var cnt = Umbraco.Content(id);
            return Ok(cnt.Name);
        }
