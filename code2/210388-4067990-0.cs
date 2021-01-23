    namesapce test {
          public class A
            {
                public static int Num = 1;
        
            }
        
            class Programs:A
            {
        
                public A A()
                {
                    Console.WriteLine(test.A.Num);
                    return new A();
                }
            }
    }
