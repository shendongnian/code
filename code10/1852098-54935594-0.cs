    static void Main(string[] args)
    {
        string fileName = @"C:\Users\thoma\Documents\Visual Studio 2019\Backup Files\data.txt";
        var arrText = File.ReadLines(fileName).ToList();         
        foreach (string sOutput in arrText)
            Console.WriteLine(sOutput);
        Console.WriteLine("Order alphabetically ascending press 'a': ");
        Console.WriteLine("Ordener descendant alphabetical press 'b': ");                       
        var instruccion = Console.ReadLine();
        IEnumerable<string> resultList;
        if (instruccion == "a")
            resultList = arrText.Where(o => o.ToLower().StartsWith("r")).OrderBy(o => o);
        else if (instruccion == "b")
             resultList = arrText.Where(o => o.ToLower().StartsWith("r")).OrderByDescending(o => o);
        else
            resultList = Enumerable.Empty<string>();
           
        foreach(var item in resultList)
            Console.WriteLine(item);    
     
        Console.ReadLine();
    }
