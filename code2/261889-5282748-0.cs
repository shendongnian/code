    namespace CSharpConsoleTest
    {
        public class MyClass
        {
            public int My1 { get; set; }
            public int My2 { get; set; }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                var obj = Activator.CreateInstance(null, "CSharpConsoleTests.MyClass");
                var t = (MyClass)obj.Unwrap();
                t.My1 = 100;
                MessageBox.Show(t.My1.ToString());
            }
        }
    }
