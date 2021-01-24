`
static void Main(string[] args)
{
   List<string> Customers = new List<string>();
   Customers.Add("Faizan");
   Customers.Add("Ali");
   Customers.Add("Fazeel");
   Customers.Add("Salim");
   Customers.Add("Mueen");
   Customers.Add("Haleem");
   Customers.Add("Mazin");
   foreach(var customer in Customers.OrderBy(s => s.Length))
   {
      Console.WriteLine(customer);
   }
   Console.ReadKey();
}
`
The method `OrderBy` takes an object of type `IEnumerable<T>` and converts it to a different `IEnumerable<T>`.
You still have to iterate through each item if you want to do something with them.
