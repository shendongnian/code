    class MyObject
    {
        public MyObject(int i)
        {
            this.Number = i;
        }
        public int Number { get; private set; }
        private int NumberPlus { get { return Number + 1; } }
        public void DoAction(Action<MyObject> action)
        {
            action(this);
        }
        public void PrintNumberPlus()
        {
            DoAction(self => Console.WriteLine(self.NumberPlus));  // has access to private `NumberPlus`
        }
    }
    MyObject obj = new MyObject(20);
    obj.DoAction(self => Console.WriteLine(self.Number));     // ok
    obj.PrintNumberPlus();                                    // ok
    obj.DoAction(self => Console.WriteLine(self.NumberPlus)); // error
