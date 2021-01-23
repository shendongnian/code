    string[] valnames = rk2.GetValueNames();
    
    for (int i = valnames.Length - 1; i >= 0; i--)
    {
        string k = valnames[i];
        if (k == "MRUListEx")
            continue;
        
        Byte[] byteValue = (Byte[])rk2.GetValue(k);
        UnicodeEncoding unicode = new UnicodeEncoding();
        string val = unicode.GetString(byteValue);
        
        richTextBoxRecentDoc.AppendText("\n" + k + ") " + val + "\n");
    }
