    SPFieldMultiChoiceValue choices = new SPFieldMultiChoiceValue(item["MultiChoice"].ToString());
    for (int i = 0; i < choices.Count; i++)
    {
        Console.WriteLine(choices[i]);
    }
