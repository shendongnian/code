public static void FindSandy(params string[] ocean)
{
    bool found = false;
    int position = -1;
    for (int i = 0; i < ocean.Length; i++)
    {
        if (ocean[i] == "Sandy")
        {
            position = i;
            found = true;
            break;
        }
    }
    if (found)
    {
        Console.WriteLine("We found Sandy on position {0}", position);
    }
    else
    {
        Console.WriteLine("He was not here");
    }
}
