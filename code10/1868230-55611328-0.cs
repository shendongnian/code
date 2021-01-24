     foreach (Customer customer in CustomerList)
            { 
               foreach (KartelesPelaton p in customer.KartelesPelaton.OrderBy(p => p.Imerominia))
                {
                  if (p.IsInvoice)
                    {
                        if (p.Credit.HasValue)
                          {
                              p.Charge = p.Credit;
                              p.Credit = null;
                          }
                    }
