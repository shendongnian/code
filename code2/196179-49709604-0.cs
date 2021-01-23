     public abstract class BaseTemp
    {
        public void printBase() {
            Console.WriteLine("base");
            print();
        }
        public abstract void print();
        
    }
    public class TempA: BaseTemp
    {
        public override void print()
        {
            Console.WriteLine("TempA");
        }
    }
    public class TempB: BaseTemp
    {
        public override void print()
        {
            Console.WriteLine("TempB");
        }
    }
