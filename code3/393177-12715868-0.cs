    [DataContract]
    public class InfoJson
    {
        [DataMember]
        public int id { get; set; }
        public static InfoJson[] parseArray(String json)
        {
            var serializer = new DataContractJsonSerializer(typeof(InfoJson[]));
    
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (InfoJson[]) serializer.ReadObject(ms);
            }
        }
    }
