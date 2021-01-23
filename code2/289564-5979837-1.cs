    namespace Your.Namespace
    {
        public class Foo
        {
            public DateTime SixtyDaysFromNow()
            {
                return DateTime.Now + new TimeSpan(60,0,0,0);
            }
        }
        public class CreateInstance1
        {
            public static void Main(string[] args)
            {
                try
                {
                    var x = Activator.CreateInstance(null, "Your.Namespace.Foo");
                    Foo f = (Foo) x.Unwrap();
                    Console.WriteLine("Result: {0}", f.SixtyDaysFromNow().ToString("G"));
                }
                catch (System.Exception exc1)
                {
                    Console.WriteLine("Exception: {0}", exc1.ToString());
                }
            }
        }
    }
