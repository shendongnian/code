    public class ClassB
    {
        public ClassB(string typeInfo)
        {
            var typeOfT = Type.GetType(typeInfo);
            var type = typeof(ClassA<>).MakeGenericType(typeOfT);
            var instance = Activator.CreateInstance(type);
        }
    }
