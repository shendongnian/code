    internal class Program
    {
        //An example delegate target
        static void Click(object o, EventArgs e) { }
        //A simple test method
        static void Main(string[] args)
        {
            EventHandler onclick = Click;
            EventHandler<EventArgs> converted;
            if (!TryConvertDelegate(onclick, out converted))
                throw new Exception("failed");
        }
        //The conversion of one delegate type to another
        static bool TryConvertDelegate<TOldType, TNewType>(TOldType oldDelegate, out TNewType newDelegate)
            where TOldType : class, System.ICloneable, System.Runtime.Serialization.ISerializable
            where TNewType : class, System.ICloneable, System.Runtime.Serialization.ISerializable
        {
            if (!typeof(Delegate).IsAssignableFrom(typeof(TOldType)) || !typeof(Delegate).IsAssignableFrom(typeof(TNewType)))
                throw new ArgumentException(); //one of the types is not a delegate
            newDelegate = default(TNewType);
            Delegate handler = oldDelegate as System.Delegate;
            if (handler == null)
                return true; //null in, null out
            Delegate result = null;
            foreach (Delegate d in handler.GetInvocationList())
            {
                object copy = System.Delegate.CreateDelegate(typeof(TNewType), d.Target, d.Method, false);
                if (copy == null)
                    return false; // one or more can not be converted
                result = System.Delegate.Combine(result, (System.Delegate)copy);
            }
            newDelegate = result as TNewType;
            return (newDelegate != null);
        }
