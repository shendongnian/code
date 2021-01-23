    private void ReplaceBoldText(Microsoft.Office.Interop.Word.Document doc)
    {
        foreach(Microsoft.Office.Interop.Word.Range rng in doc.StoryRanges)
        {
            foreach (Microsoft.Office.Interop.Word.Range rngWord in rng.Words)
            {
                if (rngWord.Bold != 0)
                {
                    rngWord.Bold = 0;
                    rngWord.Text = "<b>" + rngWord.Text + "</b>";
                }
            }
        }
    }
