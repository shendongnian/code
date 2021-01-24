    public UTCTime(string UTCStart , string UTCStop , string Fark , char Sezon)
    {
        this.UTCBas = Convert.ToDateTime(UTCStart);
        this.UTCSon = Convert.ToDateTime(UTCStop); // <----
        this.Fark = TimeSpan.Parse(Fark);
        this.Sezon = Sezon;
    }
