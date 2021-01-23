    items = AllItems.Select(item =>
                    {
                        long value;
                        bool parseSuccess = long.TryParse(item.Key, out value);
                        return new { Key = value, parseSuccess, item.Value };
                    })
                    .Where(parsed => parsed.parseSuccess)
                    .GroupBy(o => o.Key)
                    .ToDictionary(e => e.Key, e => e.First().Value)
