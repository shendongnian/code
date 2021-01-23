    var list = new List<Something>()
    {
       new Something(){SomethingID = 1,Name="John", Colors = {Color.Red,Color.Black}},
       new Something(){SomethingID = 2,Name="George", Colors = {Color.Bisque,Color.Blue}},
       new Something(){SomethingID = 3,Name="Chris", Colors ={Color.Khaki,Color.Cornsilk}}
    };
    foreach (var item in list)
    {
        Console.WriteLine(item.Name);
        foreach (var color in item.Colors)
        {
            Console.WriteLine(color.ToString());
        }
        Console.WriteLine("");
    }
