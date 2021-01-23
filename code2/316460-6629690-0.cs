        Hashtable frequency = new Hashtable();
        Hashtable grouplist = new Hashtable();
        SortedList Grp = new SortedList(grouplist);
        foreach(DictionaryEntry entry in Grp) {
            file.Write(entry.Key);
            file.Write("\t");
            file.Write(entry.Value);
            file.Write("\t");
            object maxVal = grouplist[entry.Key];
            if(maxVal != null)
                file.WriteLine(maxVal);
            file.WriteLine();
        }
