       public  class Foo : IDisposable
        {
            IDisposable boo;
    
            public virtual void Dispose()
            {
                boo?.Dispose();
            }
        }
        public class Bar : Foo
        {
            IntPtr unmanagedResource = IntPtr.Zero;
            ~Bar()
            {
                this.Dispose();
            }
    
            public override void Dispose()
            {
                CloseHandle(unmanagedResource);
                base.Dispose();
            }
    
            void CloseHandle(IntPtr ptr)
            {
                //whatever
            }
        }
