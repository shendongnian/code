    class Program
        {
            static void Main(string[] args)
            {
                var obj1 = new MyClass(MyEnum.One);
                var obj2 = new MyClass(MyEnum.Two);
                var obj3 = new MyClass(MyEnum.One);
                var obj4 = new MyClass(MyEnum.Two);
    
                var lst = new List<MyClass>() {obj1,obj2,obj3,obj4};
                var studentQuery2 =
                    from obj in lst
                    group obj by obj.enumr8 into g
                    select g.Key;
    
    
                
            }
        }
    
        class MyClass
        {
            public MyEnum enumr8;
    
            public MyClass(MyEnum enumr8_Val)
            {
                this.enumr8 = enumr8_Val;  
            }
        }
    
        enum MyEnum
        { 
            One=1,
            Two
        }
