    var res =   from e in records
                            group e by e._invoiceNumber into g
                            where g.Count() >= 1
                            select new
                            {
                                Invoice = g.Key,
                                Total = g.Count(),
                                TotalQty = g.Sum(x => Convert.ToInt32( x._orderQty.ToString()))
                            };
                            foreach(var item in res)
                            {
                                Console.WriteLine($" {item.Invoice}  :   {item.TotalQty}  ");
                            }
