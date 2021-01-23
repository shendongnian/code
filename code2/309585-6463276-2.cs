        private TimeSpan ParseDurationLine(string line)
        {
            var itemsOfData = line.Split(" "[0], "="[0]).Where(s => string.IsNullOrEmpty(s) == false).Select(s => s.Trim().Replace("=", string.Empty).Replace(",", string.Empty)).ToList();
            string duration = GetValueFromItemData(itemsOfData, "Duration:");
            return TimeSpan.Parse(duration);
        }
        private string GetValueFromItemData(List<string> items, string targetKey)
        {
            var key = items.FirstOrDefault(i => i.ToUpper() == targetKey.ToUpper());
            if (key == null) { return null; }
            var idx = items.IndexOf(key);
            var valueIdx = idx + 1;
            if (valueIdx >= items.Count)
            {
                return null;
            }
            return items[valueIdx];
        }
