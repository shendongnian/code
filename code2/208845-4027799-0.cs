    public class ClassA
    {
        Lazy<double> value = new Lazy<double>(()=>something.SomethingComplicated());
    
        public void AnyMethod()
        {
            double d = value.Value;
            //...
        }
    
    }
