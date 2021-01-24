    static void ProcessQuestionForPerson(string word)
    {
        var array = word.Split(' ');
        bool fileExisted = false;
        if (word.Contains("Wh"))
        {
            person = array[2].Substring(0,array[2].Length-1);
        }
        else
        {
            person = array[1];
        }
        fileExisted = File.Exists(person+".txt");
        if (!fileExisted)
        {
            Console.WriteLine("Who is {0}?", person);
            string data = Console.ReadLine();
            var filestream = File.Create(person + ".txt");
            byte[] b = ASCIIEncoding.ASCII.GetBytes(data);
            filestream.Write(b, 0, b.Length);
            filestream.Close();
        }
        if (word.StartsWith("Who") && fileExisted)   //We don't want to answer "Who" when we've just answered it ourselves (remove && fileExisted if you do)
        {
            string data = File.ReadAllText(person + ".txt");
            Console.WriteLine("{0} is a {1}", person, data);
        }
        if (word.StartsWith("Where"))
        {
            MatchProffesionsWithProperties(person, DateTime.Today.DayOfWeek);
        }
    }
