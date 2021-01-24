    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
    private List<Customer> CustomerList { get; set; }
    void TotalBankBalance()
    {
        Console.WriteLine("Please Enter the name for check the total balance");
        Customer SearchResult = CustomerList.FirstOrDefault(x => x.Name == Console.ReadLine());
        if (SearchResult != null)
        {
            Console.WriteLine("{0} your total bank balance is {1:C2}", SearchResult.Name, SearchResult.Balance);
        }
        else
        {
            Console.WriteLine("The Customer is not present in our database");
        }
    }
