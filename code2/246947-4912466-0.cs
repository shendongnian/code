    private static object objSync = new object();
    private int a = 0;
    
        public void function()
        {
          int b;
          lock(objSync)
            b = a;
          b += 2;
    
          //million lines of code
    
          b +=3;
          lock(objSync)
          {
            a = b;
            Console.WriteLine(a.ToString());
            a=0;
          }
        }
