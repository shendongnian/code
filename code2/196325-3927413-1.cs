    [ComVisible(true)]
    public interface IProxy
    {
        void Test( ref object integers);
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class Proxy : IProxy
    {
        [ComVisible(true)]
        public void Test(ref object intObj)
        {
            var integers = (int[])intObj;
            integers[0] = 999;
        }
    }
