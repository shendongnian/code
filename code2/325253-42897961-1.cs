    var packesCount = await botContext.Sales.Where(s => s.CustomerId == cust.CustomerId && s.Validated)
                                    .SumAsync(s => (int?)s.PackesCount);
                                if(packesCount != null)
                                {
                                    // your code
                                }
                                else
                                {
                                    // your code
                                }
