public static void FindSandy(params string[] ocean)
{
    int position = -1;
    for (int i = 0; i < ocean?.Length; i++)
    {
        if (ocean[i] == "Sandy")
        {
            position = i;
            break;
        }
    }
    if (position > -1)
    {
        Console.WriteLine("We found Sandy on position {0}", position);
    }
    else
    {
        Console.WriteLine("He was not here");
    }
}
The code can be simplified a little with the `System.Linq` extension methods `Select` (to select the name and then index) and `FirstOrDefault` which returns the first item that meets a condidion, or the default for the type (which is `null`):
    public static void FindSandy(params string[] ocean)
    {
        var position = ocean?.Select((name, index) => new {name, index})
            .FirstOrDefault(item => item.name == "Sandy");
        Console.WriteLine(position == null 
            ? "He was not here" 
            : $"We found Sandy on position {position.index}");
    }
