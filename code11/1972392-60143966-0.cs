int index = random.Next(CustomerList.Count);
var customer = CustomerList[index];
Console.WriteLine($"customer name = {customer.Name}, flavour = {customer.Flavour}}");
2. Override the ToString implementation
class Customer 
{
   //...
   // Existing code
   // ..
   public override string ToString ()
   {
       return $"customer name = {customer.Name}, flavour = {customer.Flavour}}";
   } 
}
In your main method
int index = random.Next(CustomerList.Count);
var customer = CustomerList[index];
Console.WriteLine(customer);
