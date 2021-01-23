    var doc = XDocument.Parse("<Customers>...</Customers>");
    var result = doc.Root
                    .Elements()
                    .Select(e => (int)e.Attribute("Id"))
                    .Aggregate(
                        Tuple.Create(int.MinValue, int.MaxValue),
                        (t, x) => Tuple.Create(Math.Max(t.Item1, x),
                                               Math.Min(t.Item2, x)));
    var maxId = result.Item1;
    var minId = result.Item2;
