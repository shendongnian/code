    public IEnumerable<Titem> GetItems(Tpriority priority)
        {
            // Find all the keys in the dictionary which do not match the supplied value
            var validKeys = value.Keys.Where(x => !x.Equals(priority) );
            // Find all the values in the dictionary where the key is in the valid keys list
            var validItems = value
                .Where(x => validKeys.Contains(x.Key));
            // Because an individual queue item is actually a collection of items,
            // SelectMany flattens them all into one collection
            var result = validItems.SelectMany(x => x.Value);
            return result;
        }
