    public abstract class MyAbstractClass<T>
    {
        public static string MyAbstractString{ get; set; }
        public static string GetMyAbstracString()
        {
            return "Who are you? " + MyAbstractString;
        
        }
    }
    public class MyDerivedClass : MyAbstractClass<MyDerivedClass>
    {
        public static new string MyAbstractString
        { 
            get 
            { 
                return MyAbstractClass<MyDerivedClass>.MyAbstractString; 
            }
            set
            {
                MyAbstractClass<MyDerivedClass>.MyAbstractString = value;            
            }
        }
    }
    public class MyDerivedClassTwo : MyAbstractClass<MyDerivedClassTwo>
    {
        public static new string MyAbstractString
        {
            get
            {
                return MyAbstractClass<MyDerivedClassTwo>.MyAbstractString;
            }
            set
            {
                MyAbstractClass<MyDerivedClassTwo>.MyAbstractString = value;
            }
        }
    }
    public class Test
    {
        public void Test()
        {
            MyDerivedClass.MyAbstractString = "I am MyDerivedClass";
            MyDerivedClassTwo.MyAbstractString = "I am MyDerivedClassTwo";
            Debug.Print(MyDerivedClass.GetMyAbstracString());
            Debug.Print(MyDerivedClassTwo.GetMyAbstracString());
            
        
        }
    
    }
