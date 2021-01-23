       List<string> sList = new List<string>();
        Regex pattern = new Regex(@"\(|\)|&&|\|\||\d+");
        Match match = pattern.Match(text);
        while (match.Success)
        {
            sList.Add(match.Value);
            //Console.WriteLine(text2[nCounter]);
            match = match.NextMatch();
           
        }string text = "(54&&1)||15";     
     
