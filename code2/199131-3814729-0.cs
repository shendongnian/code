    abstract class LegacyWebService
    {
        public abstract int Foo();
    }
    class RealLegacyWebService : LegacyWebService
    {
        public override int Foo()
        {
            return (int)XDocument.Load("http://www.example.com/foo").Root;
        }
    }
    class FakeLegacyWebService : LegacyWebService
    {
        public override int Foo()
        {
            return (int)XDocument.Load(@"C:\Users\Me\Desktop\foo.xml").Root;
        }
    }
