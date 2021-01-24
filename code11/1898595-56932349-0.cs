    int firstDot = ws.Cell(1, 1).GetString().IndexOf(".");
    IXLFormattedText<IXLRichText> strWithoutBold =  ws.Cell(1, 1).RichText.Substring(firstDot);
    ws.Cell(1, 1).RichText.ClearText();
    foreach (IXLRichString rt in strWithoutBold)
    {
        ws.Cell(1, 1).RichText.AddText(rt.Text).CopyFont(rt);
    }
