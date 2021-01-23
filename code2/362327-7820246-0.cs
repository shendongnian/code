    public abstract class abstractClassA
    {
        public abstract int abstractMethodA(int parameter);
    }
    
    public class usualClass : abstractClassA
    {
        [DllImort("ExternalLib.dll", EntryPoint="TheFunctionName")]
        private static extern abstractMethodAextern(int parameter);
     
        public override int abstractMethodA(int parameter)
        {
            return abstractMethodAextern(parameter);
        }
    }
