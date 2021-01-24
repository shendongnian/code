    var dbWords = new string[2000];
    for (int i = 1; i <= 2000; i++)
    {
        dbWords[i] = db.GetWordById(i); //if something else can be used to read these 2000 words from the database, this time can be reduced even more
    }
    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            for (int i = 0; i < dbWords.Length; i++)
            {
                if (line.Contains(dbWords[i]))
                {
                    int idWord = db.GetIdWordByName(dbWords[i]);
                    db.AddItemToSentences(idWord, line.Trim());
                }
            }
        }
    }
