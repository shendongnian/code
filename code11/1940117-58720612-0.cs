private void BeAmazing (int number) 
{
    try 
    {
        HandleNumber(number);
        Console.WriteLine($"This number is amazing");
    } 
    catch( Exception ex ) 
    {
        Console.WriteLine(ex.Message);
    }
}
private void HandleNumber(int number) {
   if (number > 3) {
      return;
   }
   throw new Exception("Number is 3 or less");
}
   
public static void Main()
{
    var p = new Program();
    p.BeAmazing(5);
    p.BeAmazing(3);
}
This number is amazing
Number is 3 or less
