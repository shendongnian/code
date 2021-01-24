    public class WillyTC
    {
        public string PerimetreExterne { get; }
        public string PerimetreInterne { get; }
        public string NbDecoupeInterne { get; }
        public string AireBrut { get; }
        public string AirePiece { get; }
        public string Pliages { get; }
        public string Epaisseur { get; }
        public string LongueurRect { get; }
        public string LargeurRect { get; }
        public string NumeroMateriel { get; }
        public string RPliage { get; }
        public string VPliage { get; }
        public WillyTC() : this("fr") { }
        public WillyTC(string cultureName)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            PerimetreExterne = Resources.strings.PerimetreExterne;
            PerimetreInterne = Resources.strings.PerimetreInterne;
            NbDecoupeInterne = Resources.strings.NbDecoupeInterne;
            AireBrut = Resources.strings.AireBrut;
            AirePiece = Resources.strings.AirePiece;
            Pliages = Resources.strings.Pliages;
            Epaisseur = Resources.strings.Epaisseur;
            LongueurRect = Resources.strings.LongueurRect;
            LargeurRect = Resources.strings.LargeurRect;
            NumeroMateriel = Resources.strings.NumeroMateriel;
            RPliage = Resources.strings.RPliage;
            VPliage = Resources.strings.VPliage;
        }
    }
