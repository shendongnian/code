    [DataContract]
    [KnownType(typeof(B))]
    public abstract class A
    {
        [DataMember]
        public String S { get; set; }
    }
    [DataContract]
    public class B : A
    {
        [DataMember]
        public Int32 Age { get; set; }
    }
    public static String ToJson<T>(this T value)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, value);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
