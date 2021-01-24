    static void Main(string[] args)
            {
                using(var _salesContext = new SalesDBContext())
                {
                    _salesContext.Orders.Add(new Order()
                    {
                        Date = DateTime.Now,
                        Name = "Now"
                    });
                    _salesContext.Orders.Add(new Order()
                    {
                        Date = new DateTime(2019, 2, 1),
                        Name = "Problem"
                    });
                    _salesContext.Orders.Add(new Order()
                    {
                        Date = new DateTime(2019, 5, 5),
                        Name = "Problem2"
                    });
                    _salesContext.Orders.Add(new Order()
                    {
                        Date = new DateTime(2017, 10, 20),
                        Name = "Old"
                    });
                    _salesContext.SaveChanges();
                    var orders = _salesContext.Orders
                                             .Where(o => o.Date > new DateTime(2019, 1, 1))
                                             .Take(2).OrderBy(o => o.Date)
                                             .ToList();
                    foreach(var order in orders)
                        Console.WriteLine(order.Name);
                }
            }
