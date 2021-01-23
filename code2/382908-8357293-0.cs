    public class SomeClass{
        private static object lockObject = new object();
    
        public void Foo(){
            lock(lockObject){
                for (int i = 0; i < 10000; i++)
                {
                    printValue(i);
                }
            }
        }
        
        private void printValue(int value)
        {
            Console.WriteLine(value);
        }
    }
