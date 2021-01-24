    /// <summary>
        /// Custom model binder to be used when TrackableEntities coming in HttpPost Methods.
        /// </summary>
        public class TrackableEntityModelBinder : IModelBinder
        {
            /// <inheritdoc/>
            public async Task BindModelAsync(ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                {
                    throw new ArgumentNullException(nameof(bindingContext));
                }
    
                using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body))
                {
                    var body = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
    
                    // Do something
                    var value = JsonConvert.DeserializeObject(body, bindingContext.ModelType, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    });
    
                    bindingContext.Result = ModelBindingResult.Success(value);
                }
            }
        }
