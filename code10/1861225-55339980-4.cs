    class C : A
    {
        private string s = "hello";
        public override void Start()
        {
            base.Start();
            Console.WriteLine("Starting C: " + s);
        }
    }
