    public class Shipment {
      public Guid ShipmentUniqueIdentifier{get;set;}
      public string PortOfOrigin{get;set;}
      public string PortOfDestination{get;set;}
      public ICollection<Invoice> Invoices{get;set;}
    }
    
    public class Invoice {
      public string InvoicePeriod {get;set;}
      public decimal Amount {get;set;}
    }
    
    List<Shipment> shipments = new List<Shipment>
    {
        new Shipment { PortOfOrigin = "USLOS", PortOfDestination = "UKLON", ShipmentUniqueIdentifier = Guid.NewGuid(),
            Invoices = new List<Invoice>
            {
                new Invoice{InvoicePeriod = "201106", Amount = 1000},
                new Invoice{InvoicePeriod = "201106", Amount = 2000},
                new Invoice{InvoicePeriod = "201107", Amount = 1000}
            }
        },
        new Shipment { PortOfOrigin = "USLOS", PortOfDestination = "UKLON", ShipmentUniqueIdentifier = Guid.NewGuid(),
            Invoices = new List<Invoice>
            {
                new Invoice{InvoicePeriod = "201106", Amount = 3000},
                new Invoice{InvoicePeriod = "201107", Amount = 2000}
            }
        },
        new Shipment { PortOfOrigin = "USDAL", PortOfDestination = "UKLON", ShipmentUniqueIdentifier = Guid.NewGuid(), 
            Invoices = new List<Invoice>
            {
                new Invoice{InvoicePeriod = "201106", Amount = 3000}
            }
        }
    };
    
    void Main()
    {
    	//first flatten the data so it's easier to manipulate
        var query = from s in shipments
                    from i in s.Invoices
                    select new
                    {
                        s.ShipmentUniqueIdentifier,
                        s.PortOfOrigin,
                        s.PortOfDestination,
                        i.InvoicePeriod,
                        i.Amount
                    };
        
        //group the data as desired
        var grouping = query.GroupBy(q => new { q.PortOfOrigin, q.PortOfDestination, q.InvoicePeriod });
        
        //finally sum the amounts
        var results = from g in grouping
                      select new
                      {
                          g.Key.PortOfOrigin,
                          g.Key.PortOfDestination,
                          g.Key.InvoicePeriod,
                          Amount = g.Select(s => s.Amount).Sum(),
                          NumberOfShipments = g.Distinct(s => s.ShipmentUniqueIdentifier).Count(),
                          SummarizedShipments = g.Distinct(s => s.ShipmentUniqueIdentifier).Count()
                      };
        //output the results
        foreach (var r in results)
        {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", r.PortOfOrigin, r.PortOfDestination, r.InvoicePeriod, r.Amount, r.NumberOfShipments, r.SummarizedShipments);
        }
    }
