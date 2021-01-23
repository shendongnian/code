    reply.TransactionSplitLines = reply.TransactionSplitLines.Concat(
                                  new []{
                                           new TransactionSplitLine
                                           {
                                              Amount = "100", 
                                              Category = "Test",
                                              SubCategory = "Test More", 
                                              CategoryId=int.Parse(c)
                                           }
                                        }
                                  ).ToList();
