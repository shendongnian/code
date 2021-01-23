        class Program
        {
            static void Main(string[] args)
            {
                MyExtension ext = new MyExtension();
                ext.MyEvent += ext_MyEvent;
                ext.Dosomething();
                Console.ReadLine();
            }
    
            static void ext_MyEvent(object sender, int num)
            {
                Console.WriteLine("Event fired.... "+num);
            }
        }
    
        public class MyExtension
        {
            public event EventHandler<int> MyEvent;
    
            public void Dosomething()
            {
                int no = 1;
    
                if (MyEvent != null)
                    MyEvent(this, ++no);
            }
        }
    }
