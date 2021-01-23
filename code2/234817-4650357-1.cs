            A a1 = new A();
            Console.WriteLine(A.GetCount<A>());
            A a2 = new A();
            Console.WriteLine(A.GetCount<A>());            
            using(B b1 = new B())
            {
                Console.WriteLine(B.GetCount<B>());
            }
            Console.WriteLine(B.GetCount<B>());
