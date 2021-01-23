    // Make more general if you want, with parameters for the separator, length etc
    public static string PadCommaSeparated(string text)
    {
        StringBuilder builder = new StringBuilder();
        int start = 0;
        int nextComma = text.IndexOf(',');
        while (nextComma >= 0)
        {
            int itemLength = nextComma - start;
            switch (itemLength)
            {
                case 0:
                    builder.Append("00,");
                    break;
                case 1:
                    builder.Append("0");
                    goto default;
                default:
                    builder.Append(text, start, itemLength);
                    builder.Append(",");
                    break;
            }
            start = nextComma + 1;
            nextComma = text.IndexOf(',', start);
        }
        // Now deal with the end...
        int finalItemLength = text.Length - start;
        switch (finalItemLength)
        {
            case 0:
                builder.Append("00");
                break;
            case 1:
                builder.Append("0");
                goto default;
            default:
                builder.Append(text, start, finalItemLength);
                break;
        }
        return builder.ToString();
    }
