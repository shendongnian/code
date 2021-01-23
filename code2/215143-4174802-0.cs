    class Obj
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }
        public int Prop4 { get; set; }
        public int Prop5 { get; set; }
        public int Prop6 { get; set; }
        public int Prop7 { get; set; }
        public int Prop8 { get; set; }
    }
    
    static void With<T>(T obj, Action<T> a)
    {
        a(obj);
    }
    
    
    
    static void Main(string[] args)
    {
        var detailedName = new Obj();
        With(detailedName, o =>
            {
                o.Prop1 = 1;
                o.Prop2 = 2;
                o.Prop3 = 3;
                o.Prop4 = 4;
            }
        );
    }
