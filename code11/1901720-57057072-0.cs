      static void Main(string[] args)
        {
            child sample = new child();
            sample.x = 20;
            sample.y = 15;
            sample.sum();
            Console.ReadLine();
        }
        public class parent
        {
            public int x { get; set; }
            public int y { get; set; }
            public virtual void sum()
            {
                Console.WriteLine("From Base " + (x + y));
            }
            public virtual void DoSum()
            {
                parent a = new parent();
                a.x = this.x;
                a.y = this.y;
                a.sum();
            }
        }
        class child : parent
        {
            public override void sum()
            {
                base.DoSum();
            }
        }
