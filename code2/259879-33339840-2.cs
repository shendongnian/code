    namespace OOPSProj
    {    
        class Program
        {    
            private int i;    
            public void Methode1()
            {
                Program objprog2 = new Program();
                objprog2.i = 15;
                Console.WriteLine("i= " + objprog2.i);
            }    
            static void Main(string[] args)
            {
                Program objprog = new Program();
                objprog.i = 10;
                Console.WriteLine("i= " + objprog.i);
                objprog.Methode1();                
            }
        }    
        class Test
        {
            static void Main()
            {
                Program objproj3 = new Program();
                objproj3.Methode1();    
            }          
        }    
    }
