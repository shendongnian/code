    items = AllItems.Select(item =>
                    {                         
                        long value;                         
                        bool parseSuccess = long.TryParse(item.Key, out value);                         
                        return new { value = value, parseSuccess, item.Value };                     
                    })                     
                    .Where(parsed => parsed.parseSuccess && !items.ContainsKey(parsed.value))                     
                    .Select(parsed => new { parsed.value, parsed.Value })                     
                    .GroupBy(x => x.value)
                    .Select(x => new {value = x.Key, Value = x.Min(y => y.Value)})
                    .ToDictionary(e => e.value, e => e.Value); 
