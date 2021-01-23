    public class A
    {
        // ...
        void Foo(S myStruct){...}
        void FooAsync(S myStruct)
        {
            var del = new Action<S>(Foo);
            del.BeginInvoke(myStruct, SuppressException, del);
        }
        static void SuppressException(IAsyncResult ar)
        {
            try
            {
                ((Action<S>)ar.AsyncState).EndInvoke(ar);
            }
            catch
            {
                // TODO: Log
            }
        }
    }
