    string[] valnames = rk2.GetValueNames();
    valnames = valnames.OrderBy (s => int.Parse(s)).ToArray();
    for (int i= 0 ; i < balnames.Lenght ; i++)
    {
        k = valenames[i];
        if (k == "MRUListEx")
        {
            continue;
        }
        Byte[] byteValue = (Byte[])rk2.GetValue(k);
    
        UnicodeEncoding unicode = new UnicodeEncoding();
        string val = unicode.GetString(byteValue);
    
        richTextBoxRecentDoc.AppendText("\n" + i + ") " + val + "\n");
    }
