        public class C1
        {
            public void A()
            {
                Console.WriteLine ("C1 - A");
            }
            public void B()
            {
                Console.WriteLine ("C1 - B");
            }
        }
    
        public class C2 : C1
        {
            public new void B()
            {
                Console.WriteLine ("C2 - B");
            }
        }
