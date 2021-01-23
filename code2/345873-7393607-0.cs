    public class2 
    {
        public static string MyString 
        {
           get {return "foobar"; }
        }
        
    }
    public class1 
    {
        public void DoSomething() 
        {
           MessageBox.Show(class2.MyString );
        }
    }
