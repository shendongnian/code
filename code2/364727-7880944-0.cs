    public class DateTimeConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            if (type == typeof(DateTime))
            {
                DateTime time;
                time = DateTime.Parse(dictionary["Time"].ToString(), /** put your culture info here **/);
                return time;
            }
            return null;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            DateTime? time = obj as DateTime?;
            if (time == null)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                result["Time"] = time.Value;
                return result;
            }
            return new Dictionary<string, object>();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(DateTime) })); }
        }
    }
