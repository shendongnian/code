    public static List<Item> GetItems(string filePath)
    {
        var items = new List<Item>();
        Item current = null;
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (line.StartsWith("01"))
            {
                // If there's already a current item, add it to our list
                if (current != null) items.Add(current);
                // Here we would parse the '01' line and set properties of the current item
                current = new Item {Data = line};
            }
            else if (line.StartsWith("04"))
            {
                // Here we would parse the '04' line and set properties of the current item
                current?.AssociatedData.Add(line);
            }
        }
        // Add the final item to our list
        if (current != null) items.Add(current);
        return items;
    }
