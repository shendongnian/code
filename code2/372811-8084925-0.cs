    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace JsonArrayUnionTest
    {
        public class ModifiedXX
        {
            public string yy { get; set; }
            public object mm { get; set; }
            public List<string> mmAsList()
            {
                if (null == mm) { return null; }
                if (mm is JArray)
                {
                    JArray mmArray = (JArray)mm;
                    return mmArray.Values<string>().ToList();
                }
                if (mm is JObject)
                {
                    JObject mmObj = (JObject)mm;
                    if (mmObj.Type == JTokenType.String)
                    {
                        return MakeList(mmObj.Value<string>());
                    }
                }
                if (mm is string)
                {
                    return MakeList((string)mm);
                }
                throw new ArgumentOutOfRangeException("unhandled case for serialized value for mm (cannot be converted to List<string>)");
            }
            protected List<string> MakeList(string src)
            {
                List<string> newList = new List<string>();
                newList.Add(src);
                return newList;
            }
            public void Display()
            {
                Console.WriteLine("yy is {0}", this.yy);
                List<string> mmItems = mmAsList();
                if (null == mmItems)
                {
                    Console.WriteLine("mm is null");
                }
                else
                {
                    Console.WriteLine("mm contains these items:");
                    mmItems.ForEach((item) => { Console.WriteLine("  {0}", item); });
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string jsonTest1 = "{\"yy\":\"nn\", \"mm\": [ \"zzz\", \"aaa\" ] }";
                ModifiedXX obj1 = JsonConvert.DeserializeObject<ModifiedXX>(jsonTest1);
                obj1.Display();
                string jsonTest2 = "{\"yy\":\"nn\", \"mm\": \"zzz\" }";
                ModifiedXX obj2 = JsonConvert.DeserializeObject<ModifiedXX>(jsonTest2);
                obj2.Display();
                Console.ReadKey();
            }
        }
    }
