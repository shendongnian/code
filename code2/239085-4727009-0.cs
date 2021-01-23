    public class DerivedB : InterfaceA
    {
        public string var1 { get; set; }
        public string var2 { get; set; }
        public DerivedB(InterfaceA original)
        {
           var1 = original.var1;
           var2 = original.var2;
        }
    }
