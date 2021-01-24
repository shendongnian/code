      class Base
        {
            protected int Data { get; set; }
            protected int GetData(Base obj) { return obj.Data; }
            protected void SetData(Base obj, int value) { obj.Data = value; }
        }
    
        class SubClasss1 : Base
        {
    
        }
    
        class SubClasss2 : Base
        {
            public void SetData(Base obj, int value) { this.Data = value; }
            public SubClasss1 MyFunction()
            {
                SubClasss1 x = new SubClasss1();
                this.SetData(x, this.GetData(this));
                return x;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                SubClasss2 subClass2Obj= new SubClasss2();
                subClass2Obj.SetData(subClass2Obj, 30);
                var subClass1Obj = subClass2Obj.MyFunction();
            }
        }
