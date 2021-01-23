    public static class MyClassExtensions
    {
        public static void Merge(this MyClass instanceA, MyClass instanceB)
        {
            if(instanceA != null && instanceB != null)
            {
                 if(instanceB.Prop1 != null) 
                 {
                     instanceA.Prop1 = instanceB.Prop1;
                 }
    
                 
                 if(instanceB.PropN != null) 
                 {
                     instanceA.PropN = instanceB.PropN;
                 }
        }
    }
