    class Program
    {
        static void Main(string[] args)
        {
            var class1List = new List<Class1>();
            var class2List = new List<Class2>();
            var genericList = new List<dynamic>();
            var actual = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var item in actual.Lines)
            {
                string itemJson = JsonConvert.SerializeObject(item);
                if (itemJson.Contains("PropertyA"))
                {
                    var class1 = JsonConvert.DeserializeObject<Class1>(itemJson);
                    class1List.Add(class1);
                    genericList.Add(class1);
                }
                else
                {
                    var class2 = JsonConvert.DeserializeObject<Class2>(itemJson);
                    class2List.Add(class2);
                    genericList.Add(class2);
                }
            }
        }
    }
    public class Class1
    {
        public string PropertyA;
        public string PropertyB;
    }
    public class Class2
    {
        public int Property01;
        public int Property02;
    }
