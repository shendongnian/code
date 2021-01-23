    public class Foo
    {
        public void DoStuff()
        {
            using (var x = new Thing())
            {
                throw new ApplicationException("This code breaks");
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
