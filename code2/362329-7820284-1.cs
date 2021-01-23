    public abstract class AbstractClassA
    {
        public abstract int AbstractMethodA(int parameter);
    }
    public class UsualClass : AbstractClassA
    {
        public override int AbstractMethodA(int parameter)
        {
            return NativeMethods.AbstractMethodA(parameter);
        }
    }
    [SuppressUnmanagedCodeSecurity]
    internal class NativeMethods
    {
        [DllImport("ExternalLib.dll", EntryPoint = "abstractMethodA")]
        public static extern int AbstractMethodA(int parameter);
    }
