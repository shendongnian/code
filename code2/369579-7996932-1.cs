    public class MyClass {
       public static string myString { get; set; }
    
       public void ChangeMyString(string newString)
       {
           myString = newString;
       }
    
       public void DoSomethingElse()
       {
           MessageBox.Show(myString);
       }
    
    }
