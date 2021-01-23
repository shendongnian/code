    public static IEnumerable<XElement> Filter(int min = 0, int max = int.MaxValue)
    {
        Func<XElement, int?> parse = p => {
            var element = p.Element("Price");
            if (element == null) {
                return null;
            }
            int value;
            if (!Int32.TryParse(element.Value, out value)) {
                return null;
            }
            return value;
        };
        IEnumerable<XElement> selected = (
            from x in xmlFile.Element("Stock").Elements("Product")
            let value = parse(x)
            where value >= min &&
                value <= max
            select x);
        return arr;
    }
