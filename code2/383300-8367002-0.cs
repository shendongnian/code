    public class MyClass()
    {
     private string[] Lines 
     {
       get { return PasswordLines(); }
     }
     private string[] PasswordLines(){
      string[] lines = System.IO.File.ReadAllLines(@"U:\Final Projects\Bank\ATM\db.txt");
      return lines[0].Split(" "); 
     }
    }
 
