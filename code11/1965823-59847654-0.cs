public static void FindSandy(params string[] ocean)
{
    bool found = false;
    for (int i = 0; i < ocean.Length; i++)
    {
        if (ocean[i] == "Sandy")
        {
            found = true;
            break;
        }
    }
    if (found)
    {
        Console.WriteLine("We found Sandy on position {0}", i);
    }
    else
    {
        Console.WriteLine("He was not here");
    }
}
A simpler approach, using `System.Linq` extention methods, is to use the `Any` extension method, which returns true if any items in a collection meet a condition:
public static void FindSandy(params string[] ocean)
{
    if (ocean.Any(item => item == "Sandy"))
    {
        Console.WriteLine("We found Sandy on position {0}", i);
    }
    else
    {
        Console.WriteLine("He was not here");
    }
}
