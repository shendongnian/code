    string[] lines = FormNames.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None);
        List<string> listOfLines = new List<string>();
        foreach (var i in lines)
        {
            listOfLines.Add(i);
        }
        string[] result1 = listOfLines.Where(item => item != string.Empty).ToArray();
