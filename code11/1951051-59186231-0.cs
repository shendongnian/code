    while ((line = reader.ReadLine()) != null)
    {
        string[] lineArray = line.Split(',');
        // If this line doesn't contain a comma, then skip it
        if (lineArray.Length < 2) continue;
        string annswer = lineArray[1];
        string question = lineArray[0];
        questions.Add(question);
        answers.Add(annswer);
    }
