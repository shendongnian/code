    // This markup extension returns the number of Ambient "Resource" properties
    // Found in the XAML tree above it.
    // The FrameworkElement.Resources property is already marked [Ambient]
    public class MyMarkupExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var schemaProvider = serviceProvider.GetService(typeof(IXamlSchemaContextProvider)) as IXamlSchemaContextProvider;
            var ambientProvider = serviceProvider.GetService(typeof(IAmbientProvider)) as IAmbientProvider;
            XamlMember resourcesProperty = new XamlMember(typeof(FrameworkElement).GetProperty("Resources"), schemaProvider.SchemaContext);
            List<AmbientPropertyValue> resources = (List<AmbientPropertyValue>) ambientProvider.GetAllAmbientValues(null, resourcesProperty);
            Debug.WriteLine("found {0} FramewrkElement.Resources Properties", resources.Count);
            return resources.Count.ToString();
        }
    }
