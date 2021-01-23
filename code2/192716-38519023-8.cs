    public class Class1
    {
        public static explicit operator Class2(Class1 obj)
        {
            return JsonConvert.DeserializeObject<Class2>(JsonConvert.SerializeObject(obj));
        }
    }
