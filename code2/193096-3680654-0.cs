    public class MyType1 : ICommonInterface, Type1
    {
        // Where you can define 'Somethin' in the common interface
        public string Something 
        { 
            get { return base.Something; } 
            set { base.Something = value; } 
        }
         /* ... */
    }
    public class MyType2 : ICommonInterface, Type2
    {
        // If there is no base.Something on Type2, you can re-name it assuming 
        // its intent is the same as Something
        public string Something
        {
            get { return base.SomethingElse; } 
            set { set base.SomethingElse = value; }
        }        
    }
