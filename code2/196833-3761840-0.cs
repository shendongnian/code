    string inputText = GetHtmlText();
    int scanPos = 0;
    int startTag = inputText.IndexOf("<p>", scanPos);
    while (startTag != -1)
    {
        scanPos += 4;
        // Now look for a closing tag or another open tag
        int closeTag = inputText.IndexOf("</p">, scanPos);
        int nextStartTag = inputText.IndexOf("<p>", scanPos);
        if (closeTag == -1 || nextStartTag < closeTag)
        {
            // Error at position startTag.  No closing tag.
        }
        else
        {
            // You have a full paragraph between startTag and (closeTag+5).
        }
        startTag = nextStartTag;
    }
