    public class Storage
    {
        public int a { get; set; }
        public int b => a + 5;
        public int c { get; set; }
        public void Met1()
        {
            this.a -= 10;
            this.c = this.a;
        }
        public void Met2()
        {
            this.a -= 10;
            this.c = this.a;
        }
        public void Met3()
        {
            Console.WriteLine("{0}", this.a);
            this.c = this.a;
            Met1();
            Met2();
            if (this.a > 10)
            {
                Met3();
            }
        }
    }
