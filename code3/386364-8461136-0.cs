    public class MyObject
    {
        public int Prop1 { get; set; }
        public List<Object1> TheListOfObject1 { get; set; }
        public List<Object2> TheListOfObject2 { get; set; }
        public MyObject()
        {
            TheListOfObject1 = new List<Object1>();
            TheListOfObject2 = new List<Object2>();
        }
        public string ToJson()
        {
            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            return TheSerializer.Serialize(this);
        }
        public static MyObject FromJson(string sValue)
        {
            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            return TheSerializer.Deserialize<MyObject>(sValue);
        }
    }
