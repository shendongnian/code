    foreach (var one in deserializedJson1)
    {
        if (deserializedJson2.Any(two => two.IdInTwo == one.IdInOne && two.NameInTwo == one.NameInOne))
        {
            Console.WriteLine($"Match found with {one.IdInOne} and {one.NameInOne}");
        } else
        {
            Console.WriteLine($"No match found with {one.IdInOne} and {one.NameInOne}");
        }
    }
