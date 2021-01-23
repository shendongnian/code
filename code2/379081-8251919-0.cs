    using System.Web.Script.Serialization;
    
    namespace blahblah
    {
        public partial class AccessTierService : ServiceBase
        {
            public static T ia_deserialize_json<T>(string json_string)
            {
                try
                {
                    if ((String.Compare(json_string, null) == 0) ||
                        (String.Compare(json_string, "") == 0) ||
                        (String.Compare(json_string, String.Empty) == 0))
                    {
                        return default(T);
                    }
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return (T)serializer.Deserialize<T>(json_string);
                }
                catch (Exception)
                {
                    return default(T);
                }
            }
        }
    }
