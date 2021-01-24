    public static void Main(string[] args)
    {
        var items = new List<Item>
        {
            // Second-most oldest item on Oct. 14, 2018
            new Item {Id = "14101801", Value = "Second"},
            // Fifth-most oldest item on Nov. 14, 2019
            new Item {Id = "14111901", Value = "Fifth"},
            // First-most oldest item on Oct. 13, 2018
            new Item {Id = "13101801", Value = "First"},
            // Fourth-most oldest item on Nov. 14, 2018 (id 02)
            new Item {Id = "14111802", Value = "Fourth"},
            // Third-most oldest item on Nov. 14, 2018 (id 01)
            new Item {Id = "14111801", Value = "Third"},
        };
        // Order our items by Id:
        items = items.OrderBy(i => i, new ItemComparer()).ToList();
        // Output our results
        items.ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
