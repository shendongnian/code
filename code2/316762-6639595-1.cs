    var first = searcher.Get().First(x =>
                    {
                        bool result = Satisfy(x);
                        if (!result)
                        {
                            x.Dispose();
                        }
                        return result;
                    });
