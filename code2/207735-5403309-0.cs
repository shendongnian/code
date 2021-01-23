    public interface IBase {}
    
    public interface IChildA : IBase {}
    
    public interface IChildB : IBase {}
    
    public static class BaseExtensions
    {
        public static T Touch<T>(this T self) where T : IBase { return self; }
    }
    
    public static class TestClass
    {
        public static void Test()
        {
            IChildA a = null;
            IBase firstTry = a.Touch();
    
            IChildB b = null;
            IChildB touchedB = b.Touch();
        }
    }
