    class Program
    {
        public class X { }
        public class A : X { }
        public class B : X { }
        static void Main()
        {
            List<X> list = new List<X>();
            list.Add(new B());
            list.Add(new A());
            list.Add(new B());
            list.Add(new A());
            list.Add(new A());
    
            // A.GetType() == typeof(B) will be "0" making the type A go first
            // B.GetType() == typeof(B) will be "1" making the type B go last
            var xx = list.OrderBy(x => x.GetType() == typeof(B)).ToList();
    
            Console.ReadLine();
        }
    }
