    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        Instrument instrument = obj as Instrument;
        if (instrument == null)
            return false;
        // 1. string.Equals can handle null references.
        // 2. object.ReferenceEquals for better preformances when it's the same object
        return (object.ReferenceEquals(this, instrument)) ||
            (string.Equals(ClassCode, instrument.ClassCode) &&
            string.Equals(Ticker, instrument.Ticker));
    }
    public override int GetHashCode()
    {
        int hash = 13;
        if (ClassCode != null)
            hash = (hash * 7) + ClassCode.GetHashCode();
        if (Ticker!= null)
            hash = (hash * 7) + Ticker.GetHashCode();
        return hash;
    }
