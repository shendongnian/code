    using System;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    
    namespace Quodojo.Queue
    {
        public static class CloudQueueMessageExtensions
        {
            public static CloudQueueMessage Serialize(Object o)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(o.GetType().FullName);
                stringBuilder.Append(':');
                stringBuilder.Append(JsonConvert.SerializeObject(o));
                return new CloudQueueMessage(stringBuilder.ToString());
            }
    
            public static T Deserialize<T>(this CloudQueueMessage m)
            {
                int indexOf = m.AsString.IndexOf(':');
    
                if (indexOf <= 0)
                    throw new Exception(string.Format("Cannot deserialize into object of type {0}", 
                        typeof (T).FullName));
    
                string typeName = m.AsString.Substring(0, indexOf);
                string json = m.AsString.Substring(indexOf + 1);
    
                if (typeName != typeof (T).FullName)
                {
                    throw new Exception(string.Format("Cannot deserialize object of type {0} into one of type {1}", 
                        typeName,
                        typeof (T).FullName));
                }
    
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
