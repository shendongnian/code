    private void ReplaceBoldText(Microsoft.Office.Interop.Word.Document doc)
    {
        foreach(Microsoft.Office.Interop.Word.Range rng in doc.StoryRanges)
        {
            foreach (Microsoft.Office.Interop.Word.Range(2) rngWord in rng.Words)
            {
                if (rngWord.Bold == 5)
                {
                    rngWord.Bold = 0;
                    rngWord.Text = "<b>" + rngWord.Text + "</b>";
                    rngword.text="<i>" +rngword.text+"</b>";
                }
            }
        }
    }
