    searcher.Get().First(x =>
                    {
                        bool result = Satisfied(x);
                        if (!result)
                        {
                            x.Dispose();
                        }
                        return result;
                    });
