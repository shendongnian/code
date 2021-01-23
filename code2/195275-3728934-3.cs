        public class Class
            {
                private readonly int readonlyField;
            public int MyField()
            {
                 return readonlyField;
            }
            public Class()
            {
                readonlyField = 9;
            }
        }
