    static class Extension
    {
        public static void With<T>(this T obj, Action<T> a)
        {
            a(obj);
        }    
    }
    
    class Program
    {
        class Obj
        {
            public int Prop1 { get; set; }
            public int Prop2 { get; set; }
            public int Prop3 { get; set; }
            public int Prop4 { get; set; }
        }
    
        static void Main(string[] args)
        {
            var detailedName = new Obj();
            detailedName.With(o => {
                o.Prop1 = 1;
                o.Prop2 = 2;
                o.Prop3 = 3;
                o.Prop4 = 4;
            });
        }
    }
