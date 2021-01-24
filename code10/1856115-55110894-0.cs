    public class Product
    {
        public long Id {get; set;}   
        public String Name {get; set;}  
        public String InternCode {get; set;}  
        public String producer {get; set;}
    
        public overrides string ToString()
        {
            return $"Products: {Id}  {Name}[{InternCode}] {Producer}";
        }
    }
    public static void Main(string[] args)
    {
        var products = new List<Product>();
        bool again = true;
        while(again)
        {
            var product = new Product();
            Console.WriteLine("The Id for the first product is:");
            product.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The name of the first product is:");
            product.Name = Console.ReadLine();
            Console.WriteLine("The Intern Code is:");
            product.InternCode = Console.ReadLine();
            Console.WriteLine("The producer is:");
            product.Producer = Console.ReadLine();
            products.Add(product);
            Console.WriteLine("\nEnter another product (y/n)?");
            again = (Console.ReadKey(true).Key.ToString().ToLower() == "y");
        }
        Console.WriteLine("\nThe products are:");
        foreach(var product in products)
        {
            Console.WriteLine(product);
        }
        Console.ReadKey(true);            
    }
