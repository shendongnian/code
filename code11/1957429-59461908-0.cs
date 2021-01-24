    public static void MakeBold(ref Document doc, string text)
    {
        Range range = doc.Range(0, 0);
        if (range.Find.Execute(text))
        {
            range.Font.Bold = true;
        }
    }
