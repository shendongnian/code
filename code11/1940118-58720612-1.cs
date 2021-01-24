private void BeAmazing (int number) 
{
    HandleNumber(number);
    Debug.WriteLine("number is 3 or less");
}
private void HandleNumber(int number) {
   if (number > 3) {
      throw new Exception("Number is > 3");
   }
}
public static void Main()
{
    var p = new Program();
    try 
    { 
        p.BeAmazing(5);
    } 
    catch (Exception ex ) 
    {
        Console.WriteLine(ex.Message);
    }
    p.BeAmazing(3);
Number is > 3
number is 3 or less
# Example 2
Task: Make `BeAmazing ` print different messages if `number` is >3 or not without modifying the signature of `HandleNumber`.
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
