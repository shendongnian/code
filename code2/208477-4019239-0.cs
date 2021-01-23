using System;
using System.Reflection;
 
class CallMethodByName
{
   string name;
    
   CallMethodByName (string name)
   {
      this.name = name;
   }
    
   public void DisplayName()      // method to call by name
   {
      Console.WriteLine (name);   // prove we called it
   }
    
   static void Main()
   {
      // Instantiate this class
      CallMethodByName cmbn = new CallMethodByName ("CSO");
 
      // Get the desired method by name: DisplayName
      MethodInfo methodInfo = 
         typeof (CallMethodByName).GetMethod ("DisplayName");
 
      // Use the instance to call the method without arguments
      methodInfo.Invoke (cmbn, null);
   }
}
