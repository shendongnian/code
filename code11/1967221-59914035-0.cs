    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Order order = new Order();
                List<Order> orders = order.ReadFile(FILENAME);
            }
        }
        public class Order
        {
            public DateTime date { get; set; }
            public string order { get; set; }
            public string session { get; set; }
            public string id { get; set; }
            public List<Order> ReadFile(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                List<Order> orders = new List<Order>();
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Order newOrder = new Order();
                    orders.Add(newOrder);
                    string dateStr = line.Substring(0, 24);
                    newOrder.date = DateTime.ParseExact(dateStr, "yyyy-MM-dd hh:mm:ss ffff", System.Globalization.CultureInfo.InvariantCulture);
                    string pattern = @"(?'key'[^:]+):(?'value'[^\s]+)";
                    MatchCollection matches = Regex.Matches(line.Substring(24), pattern);
                    foreach (Match match in matches.Cast<Match>().AsEnumerable())
                    {
                        string key = match.Groups["key"].Value.Trim();
                        string value = match.Groups["value"].Value.Trim();
                        switch (key)
                        {
                            case "Order" :
                                newOrder.order = value;
                                break;
                            case "session":
                                newOrder.session = value;
                                break;
                            case "ID" :
                                newOrder.id = value;
                                break;
                        }
                    }
                }
                return orders;
            }
        }
    }
