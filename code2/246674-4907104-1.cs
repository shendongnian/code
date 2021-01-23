    namespace Plugin01
    {
        public class Class1 : Interfaces.IPlugin01,Interfaces.IPlugin02
        {
            public string Name { get { return "Plugin01.Class1"; } }
            public string Description { get { return "Plugin01.Class1 description"; } }
            public void Calc1() { Console.WriteLine("sono Plugin01.Class1 Calc1()"); }
            public void Calc2() { Console.WriteLine("sono Plugin01.Class1 Calc2()"); }
        }
    
        public class Class2 : Interfaces.IPlugin01
        {
            public string Name { get { return "Plugin01.Class2"; } }
            public string Description { get { return "Plugin01.Class2 description"; } }
            public void Calc1() { Console.WriteLine("sono Plugin01.Class2 Calc1()"); }
        }
    }
