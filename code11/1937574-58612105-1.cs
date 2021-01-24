namespace MSE
{
    class Program
    {
        static List<string> list;
        private static async Task<ScanInfo> gettingCustomerInfo(string name, long Id)
        {
            // code goes here..
        }
        static async Task Main(string[] args)
        {
            list = new List<string>();
            var lines = File.ReadAllLines("c:\\file.txt");
            foreach (var line in lines)
            {
                list.Add(line);
            }
            var tasks = companies.Select(c => Task.Run(() => 
            gettingCustomerInfo(c.properties.name.value, c.companyId)));
            //code goes here...
        }
    }
}
