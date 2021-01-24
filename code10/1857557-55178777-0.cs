    class Token
    {
        public string[] Categories{get;set;}
    }
    var tokens=new []{new Token()};
    var categories = tokens.SelectMany(x => x.Categories);
    if (categories != null)
    {
        if (categories.Contains("interp")) 
        {
            Console.WriteLine("Found");
        }
    }
