 public class TagIO
 {
         //Create a private field to store your dynamic's value
         private dynamic val; 
            
         //Create a property to store Type
         public Type MyType{get;set;} 
         public string Name{get;set;}
         public dynamic Value
         {
             get
             {
                 //Return dynamic value as specified type
                 return Convert.ChangeType(val, MyType);
             }
             set
             {
                 //set dynamic value.
                 val = value;
             }
         }
}
Example Usage
TagIO tg = new TagIO();
tg.MyType = typeof(int);
tg.Value = 311;
Console.WriteLine("{0} {1}", tg.MyType.Name, tg.Value); //Int32 311
Console.ReadKey();
