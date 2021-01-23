    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public override string ToString()
        {
            return this.CustomerID + " " + this.CustomerName + " " + this.CustomerSurname;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string JSonData = @"[
            {
                 ""CustomerID"": ""1"",
	             ""CustomerName"": ""Mehmet"",
                 ""CustomerSurname"": ""Tasköprü""
            },
            {
                 ""CustomerID"": ""2"",
	             ""CustomerName"": ""Cin"",
                 ""CustomerSurname"": ""Ali""
            },
            {
                 ""CustomerID"": ""3"",
	             ""CustomerName"": ""Temel"",
                 ""CustomerSurname"": ""Reis""
            }]";
            IList<Customer> iListData = new JavaScriptSerializer().Deserialize<IList<Customer>>(JSonData);
            foreach (var item in iListData)
                Console.WriteLine(item.ToString());
            Console.Read();
        }
    }
}
