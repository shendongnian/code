    public class Class1
    {
        public static explicit operator class2(Class1 obj)
        {
            return JsonConvert.DeserializeObject<Class2>(JsonConvert.SerializeObject(obj));
        }
    }
