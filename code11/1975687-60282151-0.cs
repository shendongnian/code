    var newCollection = originalCollection.Select(x => new
                    {
                        Key = x.Key.DocumentNumber,
                        Value = x.Value.Select(y => new
                        {
                            y.SerialNumber,
                            y.Certificate
                        }).ToList()
                    });
