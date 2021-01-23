    StringBuilder builder = new StringBuilder();
    Word.Range rngFindBold =
    ((Word.DocumentClass)(wh.Document)).ActiveWindow.Selection.Range;
    rngFindBold.Find.Font.Bold = -1;
    foreach (Word.Range rngWord in rngFindBold.Words)
    {
        if (rngWord.Bold != 0)
        {
            builder.Append("<b>" + rngWord.Text + "</b>");
        }
        else if (rngWord.Italic != 0)
        {
            builder.Append("<i>" + rngWord.Text + "</i>");
        }
        else if (rngWord.Underline != 0)
        {
            builder.Append("<u>" + rngWord.Text + "</u>");
        }
        else
        {
            builder.Append(rngWord.Text);
        }
    }
