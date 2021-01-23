    class MyType : MyNum
    {
        public MyType(int num)
           : base(num)
        {
        }
        public override void Show()
        {
              Console.WriteLine("The number [MyType] is : " + this.num);
        }
    }
