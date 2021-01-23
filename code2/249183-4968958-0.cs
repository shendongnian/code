    class Data
    {
        public string Name {get;set;}
        public A Value {get;set;}
    }
    interface ITypeFG
    {
        Data Field {get;}
    }
    class B : A, ITypeFG
    {
        public Data Field 
        {
            get
            {
                return new Data {Name = "TypeF", Value = FieldB};
            }
        }
    }
    class C : A, ITypeFG
    {
        public Data Field 
        {
            get
            {
                return new Data {Name = "TypeG", Value = FieldC};
            }
        }
    }
