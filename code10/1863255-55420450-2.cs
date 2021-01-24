    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReadOnlyCollection
    {
        class Program
        {
    
            static List<Tuple<int, string>> transactions = new List<Tuple<int, string>>();
    
            static void Main(string[] args)
            {
                transactions.Add(Tuple.Create(1, "1"));
                transactions.Add(Tuple.Create(1, "11"));
                transactions.Add(Tuple.Create(2, "2"));
                transactions.Add(Tuple.Create(2, "12"));
                transactions.Add(Tuple.Create(3, "3"));
                transactions.Add(Tuple.Create(3, "13"));
                transactions.Add(Tuple.Create(4, "4"));
                transactions.Add(Tuple.Create(5, "5"));
                transactions.Add(Tuple.Create(6, "6"));
    
                Run(DateTime.Now, DateTime.Now);
            }
    
            public static List<string> Run(DateTime startDate, DateTime endDate)
            {
                var carrierIds = new List<int>() { 1,2,3,4,5,6};
    
                List<string> transactionsJson = new List<string>();
                foreach (var carrierId in carrierIds)
                {
                    var transactions = GetTransactions(
                        carrierId, startDate, endDate);
    
                    if (transactions.Count > 0)
                    {
                        var transactionJson = JsonConvert.SerializeObject(transactions);
                        transactionsJson.Add(transactionJson);
                    }
                }
                return transactionsJson;
            }
    
            public static ReadOnlyCollection<string> GetTransactions(int carrierId, DateTime beginDate, DateTime? endDate = null)
            {
                // call an external resource and save result to resultArray
                return new ReadOnlyCollection<string>(transactions.Where(item => item.Item1 == carrierId).Select(item => item.Item2).ToList());
            }
        }
    }
