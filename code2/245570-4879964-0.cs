    var query = from b in books
                select new test()
                {
                    Title = b.Title,
                    StockAvailable = bookexamples.Count(be => 
                            be.BookID == b.BookID && 
                            be.OrderDetailID == null
                        )
                };
