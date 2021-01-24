    class myclass
    {
        public bool ShowSpace { get; set; }
        public double myproperty { get; set; }
        public override ToString()
        {
            return this.ShowSpace ? " " : this.myproperty.ToString();
        }
    }
