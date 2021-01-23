    public static class ConvertExtension //exstension for convertion
    {
        //automatic convertion
        //later you define in lambda wich data needs to be converted
        public static T Convert<S, T>(this S source, Action<S, T> convert)
            where S : class
            where T : class
        {
            T target = System.Activator.CreateInstance<T>();
            convert(source, target);
            return target;
        }
        //convert data defined in interface
        //you need copy all fields manually
        public static T Convert<T>(this IData source)
            where T : IData
        {
            T target = System.Activator.CreateInstance<T>();
            target.ID = source.ID;
            target.Name = source.Name;
            return target;
        }
    }
    public interface IData //Describe common properties
    {
        int ID {get; set;}
        string Name {get; set;}
    }
    class A : IData //Interface already implemented. You just mark classes with interface
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class B : IData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
   
    //example
    A a = new A();
    B b1 = a.Convert<B>();
    B b2 = a.Convert<A, B>((s, t) => t.ID = s.ID);
