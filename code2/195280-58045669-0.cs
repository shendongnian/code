    public class MyInitClass
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }
    }
    public class Class
    {
        private readonly int readonlyField1;
        private readonly int readonlyField2;
        public Class()
        {
            var init = Init();
            readonlyField1 = init.Field1;
            readonlyField2 = init.Field2;
        }
        private MyInitClass Init()
        {
            return new MyInitClass() { Field1 = 1, Field2 = 2 };
        }
    }
