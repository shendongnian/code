    /// <summary>
    /// Defines a Capteurs
    /// </summary>
    public class Capteurs : ICloneable
    {
        public Capteurs()
        {
            this.Name=  string.Empty;
            this.Marque=  string.Empty;
            this.Model=  string.Empty;
            this.Calibre=  0;
            this.A=  string.Empty;
            this.B=  string.Empty;
        }
        public Capteurs(Capteurs other)
        {
            this.Name = other.Name;
            this.Marque = other.Marque;
            this.Model = other.Model;
            this.Calibre= other.Calibre;
            this.A=other.A;
            this.B=other.B; 
        }
        public string Name { get; set; }
        public string Marque { get; set; }
        public string Model { get; set; }
        public int Calibre { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        #region ICloneable Members
        public Capteurs Clone() => new Capteurs(this);
        object ICloneable.Clone() => Clone();
        #endregion
    }
