    public class DoSomeActionParameters
        {
            public string A { get; private set; }
            public string B  { get; private set; }
            public DateTime C { get; private set; }
            public OtherEnum D  { get; private set; }
            public string E  { get; private set; }
            public string F  { get; private set; }
    
            public class Builder
            {
                DoSomeActionParameters obj = new DoSomeActionParameters();
    
                public string A
                {
                    set { obj.A = value; }
                }
                public string B
                {
                    set { obj.B = value; }
                }
                public DateTime C
                {
                    set { obj.C = value; }
                }
                public OtherEnum D
                {
                    set { obj.D = value; }
                }
                public string E
                {
                    set { obj.E = value; }
                }
                public string F
                {
                    set { obj.F = value; }
                }
    
                public DoSomeActionParameters Build()
                {
                    return obj;
                }
            }
        }
    
        public class Example
        {
    
            private void DoSth()
            {
                var data = new DoSomeActionParameters.Builder()
                {
                    A = "",
                    B = "",
                    C = DateTime.Now,
                    D = testc,
                    E = "",
                    F = ""
                }.Build();
            }
        }
