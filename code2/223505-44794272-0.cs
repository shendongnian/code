    class Program
    {
        static void Main(string[] args)
        {
            Extension ext = new Extension();
            ext.MyEvent += ext_MyEvent;
            ext.Dosomething();
        }
        static void ext_MyEvent(int num)
        {
            Console.WriteLine(num);
        }
    }
    public class Extension
    {
        public delegate void MyEventHandler(int num);
        public event MyEventHandler MyEvent;
        public void Dosomething()
        {
            int no = 0;
            while(true){
                if(MyEvent!=null){
                    MyEvent(++no);
                }
            }
        }
    }
