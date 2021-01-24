        public static void Register(HttpConfiguration config) {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            ODataBatchHandler batchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                configureAction: builder => builder.AddService<IEdmModel>(ServiceLifetime.Singleton, sp => CreateODataModel())
                    .AddService<ODataBatchHandler>(ServiceLifetime.Singleton, bb => new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer))
                    .AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, sp => ODataRoutingConventions.CreateDefaultWithAttributeRouting("ODataRoute", config))
                    .AddService<Microsoft.AspNet.OData.Formatter.Serialization.ODataSerializerProvider>(ServiceLifetime.Singleton, sp => new MiTestSerializerProvider(sp))
                    .AddService<Microsoft.AspNet.OData.Formatter.Deserialization.ODataDeserializerProvider>(ServiceLifetime.Singleton, sp => new MiDynamicPropertiesDeserializerProvider(sp))
                );
        }
Where the deserializer is the important one in this context.
My beginning of a deserializer looks as so (it requires a provider/implementation coupling):
    public class MiDynamicPropertiesDeserializerProvider : DefaultODataDeserializerProvider
    {
        MiDynamicPropertiesDeserializer _edmSerializer;
        public MiDynamicPropertiesDeserializerProvider(IServiceProvider rootContainer) : base(rootContainer) {
            _edmSerializer = new MiDynamicPropertiesDeserializer(this);
        }
        public override ODataEdmTypeDeserializer GetEdmTypeDeserializer(IEdmTypeReference edmType) {
            switch (edmType.TypeKind()) { // Todo: Do I need more deserializers ?
                case EdmTypeKind.Entity: return _edmSerializer;
                default: return base.GetEdmTypeDeserializer(edmType);
            }
        }
    }
    public class MiDynamicPropertiesDeserializer : ODataResourceDeserializer {
        public MiDynamicPropertiesDeserializer(ODataDeserializerProvider serializerProvider) : base(serializerProvider) { }
        private static Dictionary<Type, Func<object, object>> simpleTypeConverters = new Dictionary<Type, Func<object, object>>() {           
            { typeof(DateTime), d => new DateTimeOffset((DateTime)d)  } // Todo: add converters or is this too simple ?
        };
        public override void ApplyStructuralProperty(object resource, ODataProperty structuralProperty, IEdmStructuredTypeReference structuredType, ODataDeserializerContext readContext) {
            if (structuralProperty != null && structuralProperty.Value is ODataUntypedValue) {
                // Below is a Q&D mapper I am using in my test to represent properties
                var tupl = WebApplication1.Models.RuntimeClassesHelper.GetFieldsAndTypes().Where(t => t.Item1 == structuralProperty.Name).FirstOrDefault();
                if (tupl != null) {
                    ODataUntypedValue untypedValue = structuralProperty.Value as ODataUntypedValue;
                    if (untypedValue != null) {
                        try {
                            object jsonVal = JsonConvert.DeserializeObject(untypedValue.RawValue);
                            Func<object, object> typeConverterFunc;
                            if (jsonVal != null && simpleTypeConverters.TryGetValue(jsonVal.GetType(), out typeConverterFunc))
                            {
                                jsonVal = typeConverterFunc(jsonVal);
                            }
                            structuralProperty.Value = jsonVal;
                        }
                        catch(Exception e) { /* Todo: handle exceptions ? */  }
                    }
                }
            }
            base.ApplyStructuralProperty(resource, structuralProperty, structuredType, readContext);
        }
    }
Thanks to everyone who has used time on this, I hope someone else will find this info useful.
