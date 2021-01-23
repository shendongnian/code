    [DataContract]
    public class MyCustomClass
    {
        [DataMember]
        public string foobar { get; set; }
    }
    [DataContract]
    public class ContentItemViewModel
    {
        [DataMember]
        public string CssClass { get; set; }
        [DataMember]
        public MyCustomClass PropertyB { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ContentItemViewModel model = new ContentItemViewModel();
            model.CssClass = "StackOver";
            model.PropertyB = new MyCustomClass();
            model.PropertyB.foobar = "Flow";
            //Create a stream to serialize the object to.
            MemoryStream ms = new MemoryStream();
            // Serializer the User object to the stream.
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ContentItemViewModel));
            ser.WriteObject(ms, model);
            byte[] json = ms.ToArray();
            ms.Close();
            string s=  Encoding.UTF8.GetString(json, 0, json.Length);
            Console.ReadLine();
        }
    }
