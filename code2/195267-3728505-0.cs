    public class Class
    {
        private readonly int readonlyField1;
        private readonly int readonlyField2;
    
        public Class()
        {
            Init(out readonlyField1, out readonlyField2);
        }
    
        private void Init(out int field1, out int field2)
        {
            field1 = 1;
            field2 = 2;
        }
    }
