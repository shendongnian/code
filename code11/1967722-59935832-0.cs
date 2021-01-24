    public static void Print(this ObjectInformation parent, int spacing = 2)
    {
        Console.WriteLine($"{new string(' ', spacing)}{parent.FullName}");
        foreach (ObjectInformation child in parent.Children)
        {
            child.Print(spacing + 2);
        }
    }
