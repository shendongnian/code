c#
while(!verifiedNumber) {
   Console.WriteLine("Type in a number and then press enter:");
   try { 
      num2 = Convert.ToDouble(Console.ReadLine()); 
      verifiedNumber = true;
   } 
   catch { 
      Console.WriteLine("Please Enter a valid numerical value!"); 
   }
}
