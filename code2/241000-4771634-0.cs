       public static String ToJSONString(this Object obj)
       {
         using (var stream = new MemoryStream())
         {
           var ser = new DataContractJsonSerializer(obj.GetType());
   
           ser.WriteObject(stream, obj);
   
           return Encoding.UTF8.GetString(stream.ToArray());
         }
       }
    
       public static T FromJSONString<T>(this string obj)
       {
         using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(obj)))
         {
           DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
           T ret = (T)ser.ReadObject(stream);
           return ret;
         }
       }
