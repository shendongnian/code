    public class TypelessJsonResult : JsonResult
    {
        public TypelessJsonResult(object value) : base(value)
        {
            SerializerSettings.TypeNameHandling = TypeNameHandling.None;
        }
    }
