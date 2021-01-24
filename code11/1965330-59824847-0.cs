    var results = list.GroupBy(
                p => p.Header.HeaderName,
                p => p.Detail,
                (key, g) => new HeaderDetails { Header = new Header { HeaderName = key }, Details = g.ToList() });
            foreach (var item in results)
            {
                Console.WriteLine(item.Header.HeaderName);
                foreach (var det in item.Details)
                {
                    Console.WriteLine(det.DetailName);
                }
            }
