    class IniEntry
    {
        public int BL;
        public int LK;
        public int LH;
        IniEntry Clone() { return new IniEntry { BL = BL, LK = LK, LH = LH }; }
    }
    
    IEnumerable<IniEntry> Parse()
    {
        IniEntry ie = new IniEntry();
        while (ParseEntry(out ie))
            yield return ie.Clone();
    }
    
    bool ParseEntry(out IniEntry ie)
    {
        ie = new IniEntry();
        return ParseStart(ie) &&
                   ParseBL(ie) &&
                   ParseLK(ie) &&
                   ParseLH(ie) &&
                   ParseEnd(ie);
    }
    
    bool ParseStart(IniEntry ie)
    {
        string dummy;
        return ParseLine("START", out dummy);
    }
    
    bool ParseBL(IniEntry ie)
    {
        string BL;
        return ParseLine("BL", out BL) && int.TryParse(BL, out ie.BL);
    }
    
    bool ParseLK(IniEntry ie)
    {
        string LK;
        return ParseLine("LK", out LK) && int.TryParse(LK, out ie.LK);
    }
    
    bool ParseLH(IniEntry ie)
    {
        string LH;
        return ParseLine("LH", out LH) && string.TryParse(LH, out ie.LH);
    }
    
    bool ParseLine(string key, out string value)
    {
        string line = GetNextLine();
        var parts = line.Split(":");
        if (parts.Count != 2) return false;
        if (parts[0] != key) return false;
        value = parts[1];
    }
