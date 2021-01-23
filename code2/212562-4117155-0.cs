        public class TestClass
        {
            int p;  // p's is in the 'TestClass' scope
            public void TestFunction1()
            {
                
                Console.WriteLine(p);   // OK, p in class scope
                //  a lives in the 'TestFunction' scope
                int a = 1; // Declared outside of any loop.
                for (int i = 0; i < 10; i++)
                {
                    //  i lives in the scope of this for loop
                    Console.WriteLine(i);
                    //  a is still accessible since this for loop is inside TestFunction1
                    Console.WriteLine(a);
                }
                Console.WriteLine(a); // OK, in scope
                //Console.WriteLine(i); // Error, i out of scope
                //  j also lives in the TestFunction1 scope
                int j = 0;
                for (j = 0; j < 20; j++)
                {
                    //  j still accessible within the loop since the loop is within TestFunction1
                    Console.WriteLine(j);
                }
                Console.WriteLine(j); // Ok, j still in scope (outside of loop)
            }
            public void TestFunction2()
            {
                Console.WriteLine(p);   // Ok, TestFunction2 is in the TestClass scope like TestFunction1
                //Console.WriteLine(a);   // Error, a lives in TestFunction1
                //Console.WriteLine(i);   // Error, allright now we're just getting silly ; )
            }
        }
