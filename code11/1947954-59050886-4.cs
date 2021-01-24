    var dbWords = new string[2000];
    for (int i = 1; i <= 2000; i++)
    {
        dbWords[i] = db.GetWordById(i); //if something else can be used to read these 2000 words from the database, this time can be reduced even more
    }
    using (StreamReader sr = new StreamReader("collection.csv"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            for (var index = 0; index < dbWords.Length; index++)
            {
                var dbWord = dbWords[index];
                if (line.Contains(dbWord))
                {
                    db.AddItemToSentences(index, line.Trim());
                }
            }
        }
    }
