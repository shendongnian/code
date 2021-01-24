class Program
{
    const string path = @"filePath";
    static deploy Content;
    static string Version;
    static List<string> ListOfSelectedItems;
    static List<string> TempListOfSelectedItems;
    static List<string> Channels;
    // and others
    static void Main(string[] args)
    {
        setUpValues();
    }
    private static void setUpValues()
    {
        Content = JsonConvert.DeserializeObject<deploy>(File.ReadAllText(path));
        List<Variable> variables = Content.Variables.ToList();
        Scopes Scope = Content.ScopeValues;
        Version = null;
        ListOfSelectedItems = new List<string>();
        TempListOfSelectedItems = new List<string>();
        Channels = new List<string>();
        foreach (var item in variables)
        {
            if (item.Name.Equals("version"))
            {
                Version = item.Value;
            }
            if (item.Name.Equals("Selected"))
            {
                TempListOfSelectedItems.Add(item.Value);
            }
        }
        Console.WriteLine("Version  " + Version);
        Console.WriteLine();
        string SelectedItems = TempListOfSelectedItems[0];
        ListOfSelectedItems = SelectedItems.Split(',').ToList();
        Console.WriteLine();
        Console.WriteLine("Selected Modules");
        Console.WriteLine();
        foreach (var item in ListOfSelectedItems)
        {
            Console.WriteLine(item);
        }
        foreach (var item in Scope.Channels)
        {
            Channels.Add(item.Name);
        }
    }
}
You have to declare those fields as `static` because they are used in a static method. After the `setUpValues` finishes running, you can use those fields inside the `Main` method as well.
Also, this is not related to the question, but the general code convention in C# is to start methods' names with an uppercase letter (so `SetUpValues` instead of `setUpValues`) and to start the local variables' names with a lowercase letter (`selectedItems` instead of `SelectedItems`). Obviously, it's ultimately up to you how to name things and which code convention to use.
