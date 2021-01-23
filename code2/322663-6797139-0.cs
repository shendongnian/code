    namespace Test
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public interface IThingy { }
        public interface IFoo
        {
            IEnumerable<IThingy> Thingies { get; }
        }
        internal class Thing1 : IThingy { }
        internal class ImplementFoo : IFoo
        {
            private List<Thing1> m_things = new List<Thing1>() { new Thing1() };
            public IEnumerable<IThingy> Thingies
            {
                get { return m_things; }
            }
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var impl = new ImplementFoo();
                Console.WriteLine(impl.Thingies.Count());
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
