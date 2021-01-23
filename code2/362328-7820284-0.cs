    public abstract class AbstractClassA
    {
        public abstract int AbstractMethodA(int parameter);
    }
    public class UsualClass : AbstractClassA
    {
        [DllImport("ExternalLib.dll", EntryPoint = "abstractMethodA")]
        static extern int AbstractMethodAImport(int parameter);
        public override int AbstractMethodA(int parameter)
        {
            return AbstractMethodAImport(parameter);
        }
    }
