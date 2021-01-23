    public class Foo
    {
        public void DoStuff()
        {
            var x = new Thing();
            try
            {
                throw new ApplicationException("This code breaks");
                x.Dispose();
            }
            catch (Exception err)
            {
                x.Dispose();
                rethrow;
            }
        }
    
        private class Thing : IDisposable
        {
            public override Dispose()
            {
                throw new ApplicationException("Help, I can't dispose!");
            }
        }
    }
