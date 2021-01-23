    namespace TestLibrary
        public class A {
            public virtual int X { 
                get { return 0; } 
                set { Console.WriteLine("A.set_X called."); } 
            }
        }
    }
