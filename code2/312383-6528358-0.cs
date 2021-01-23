                 // Since this is here, you're saying "MyType is a MyNum"
    class MyType : MyNum
    {
        MyNum num2;
        public MyType(MyNum num) // You need to call the base class constructor 
                                 // here to construct that portion of yourself
           : base(42) // Call this with an int...
        {
            this.num2 = num;
        }
