        public abstract class MyGenericClass<T1, T2>
        {
            public abstract void Do(T1 param1, T2 param2);
        }
        
        public class Concrete : MyGenericClass<string, int?>
        {        
            public override void Do(string param1, int? param2 = null)
            {
                Console.WriteLine("param1: {0}", param1);
                
                if (param2 == null)
                    Console.WriteLine("param2 == null");
                else
                    Console.WriteLine("param2 = {0}", param2);
        
                Console.WriteLine("=============================================");
            }        
        }
