    public class Class
    {
        private readonly int readonlyField;
        public Class()
        {
            readonlyField = Init();
        }
        private int Init()
        {
            return 1;
        }
    }
