    public void WriteCsv<T>(IEnumerable<T> items, string path)
    {
        var itemType = typeof(T);
        var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .OrderBy(p => p.Name).ToList();
        using (var writer = new StreamWriter(path))
        {
            var columns = props.Select(p => p.Name);
            writer.WriteLine(string.Join(",", columns.Select(x => "\"" + x + "\"")));
            foreach (var item in items)
            {
                var values = props.Select(p => p.GetValue(item, null));
                writer.WriteLine(string.Join(",", values.Select(x => "\"" + x + "\"")));
            }
        }
    }
