    while (enumerator2.MoveNext())
    {
        DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator2.get_Current();
        string text2 = (string)dictionaryEntry.get_Key();
        if (!uri.AbsolutePath.StartsWith(CookieParser.CheckQuoted(text2)))
        {
            if (flag2)
            {
                break;
            }
            else
            {
                continue;
            }
        }
        flag2 = true;
        CookieCollection cookieCollection2 = (CookieCollection)dictionaryEntry.get_Value();
        cookieCollection2.TimeStamp(CookieCollection.Stamp.Set);
        this.MergeUpdateCollections(cookieCollection, cookieCollection2, port, flag, i < 0);
        if (!(text2 == "/"))
        {
            continue;
        }
        flag3 = true;
        continue;
    }
