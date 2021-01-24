    bool found = false;
    for (int i = 0; i < inlägg.Length; i++)
    {
        if (item[i] == search)
        {
            // i get the element.
            Console.WriteLine("\t your search result is: " +
                "\n\tTitle: " + item[0] +
                "\n\tMessage: " +
                item[1] + "\n\t" + item[2]);
            found = true;
            break;
        }
    }
    
    if (!found)
        Console.WriteLine("\tNot found?! ");
