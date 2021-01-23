    ...
    if (ch <= '>')
    {
        switch (ch)
        {
            case '&':
            {
                output.Write("&amp;");
                continue;
            }
            case '\'':
            {
                output.Write("&#39;");
                continue;
            }
            case '"':
            {
                output.Write("&quot;");
                continue;
            }
            case '<':
            {
                output.Write("&lt;");
                continue;
            }
            case '>':
            {
                output.Write("&gt;");
                continue;
            }
        }
        output.Write(ch);
        continue;
    }
    if ((ch >= '\x00a0') && (ch < 'Ā'))
    {
        output.Write("&#");
        output.Write(((int) ch).ToString(NumberFormatInfo.InvariantInfo));
        output.Write(';');
    }
    ...
