    public abstract class ObjectToUrlConverter<Source> : ITypeConverter<Source, string>
    {
        public string Convert(ResolutionContext context)
        {
            UrlHelper Url = (UrlHelper)context.Options.Items["Url"];
            string result = null;
            if (context.SourceValue != null)
            {
                result = Url.Link(GetRouteName(), GetControllerName(), GetIdentifier((Source)context.SourceValue));
            }
            return result;
        }
        public abstract object GetIdentifier(Source sourceObject);
        public abstract string GetRouteName();
        public abstract string GetControllerName();
    }
    public class SomeEntityToUrlConverter : ObjectToUrlConverter<SomeEntity>
    {
        public override object GetIdentifier(SomeEntity sourceObject)
        {
            return sourceObject.Id;
        }
        public override string GetRouteName()
        {
            return "someRouteName";
        }
        public override string GetControllerName()
        {
            return "someControllerName";
        }
    }
