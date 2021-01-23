    if (e.Data.GetDataPresent("System.Collections.DictionaryEntry"))
    {
        System.Collections.DictionaryEntry r = (System.Collections.DictionaryEntry)e.Data.GetData("System.Collections.DictionaryEntry");
        //Use r.Key or r.Value.
        lbFav.Items.Add(r.Key);!
    }
