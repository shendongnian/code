    namespace TestLibrary
        public class A {
            public virtual int X { 
                get { return 0; } 
                private set { Console.WriteLine("A.set_X called."); } 
            }
        }
    }
