    private static IEnumerable<String> GetDataPerLines()
    {
        FileStream aFile = new FileStream("sportsResults.csv",FileMode.Open);             
        StreamReader sr = new StreamReader(aFile); 
        while ((line = sr.ReadLine()) != null)             
        { 
            yield return line;
        }             
        sr.Close(); 
    }
    static void Main(string[] args)
    {
        var query = from data in GetDataPerLines()
              let splitChr = data.Split(",".ToCharArray())
                    select new Sport
        {
           sport = splitChr[0],
           date = splitChr[1],.. and so on
        }
    
        foreach (var item in query)
        {
            Console.Writeline(" Sport = {0}, in date when {1}",item.sport,item.date);
        }
    }
