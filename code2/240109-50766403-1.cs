     public class Myobject
        {
            public Myobject(){}
            public string prop1 { get; set; }
    
            public static Myobject  GetObject(string JsonString){return  JsonExtentions.JsonToObject<Myobject>(JsonString);}
            public  string ToJson(string JsonString){return JsonExtentions.SerializeToJson(this);}
        }
