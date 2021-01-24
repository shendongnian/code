//sorts list from based on Customer ID lowest to highest
void insertionSort()
{
    customers = customers.OrderBy(x => x.customerId).ToList();
}
//can search by customer ID
void binarySearch()
{
    Console.Write("Customer ID to search:");
    var id = Convert.ToInt32(Console.ReadLine());
    var customer = customers.FirstOrDefault(x => x.customerId == id);
    if (customer != null)
    {
        Console.WriteLine(customer);
    }
    else
    {
        Console.WriteLine("Customer not found");
    }
        
}
