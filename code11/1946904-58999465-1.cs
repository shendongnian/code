    class Program
    {
        static void Main(string[] args)
        {
           var customer = null;
           var customerRepository = new CustomerRepository();
           Console.WriteLine("Is it new customer (Y/N): ");
           answer = Console.ReadLine();
           if (answer == "N")
           {
             Console.WriteLine("Pls enter ID: ");
             ID = Console.ReadLine();
             customer = customerRepository.Retrieve(ID);
           }
           else
           {
               customer = new Customer(Utilities.RandomString(6));  // Assign random ID
               customerRepository.Save(customer);
           }
       }
    } 
