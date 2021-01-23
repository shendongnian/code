    public class ListeAvisRemboursements
    {
        private readonly List<AvisRemboursement> items = new List<AvisRemboursement>();
        [XmlElement("AvisRemboursement", Namespace = "xml.AAAAAAA.com/commerce/apres-vente_technique/assistance")]
        public List<AvisRemboursement> Items { get { return items; } }
    }
    public class AvisRemboursement
    {
        [XmlAttribute] public string NumeroDT {get;set;}
        [XmlAttribute] public string CodeRA {get;set;}
        [XmlAttribute] public string NumeroDC {get;set;}
        public DateTime DateTraitement { get; set; }
        public decimal MontantDC { get; set; }
        public decimal MontantMO { get; set; }
        public decimal SommeAD { get; set; }
        public decimal MontantPR { get; set; }
        public decimal SommePR { get; set; }
        public decimal FraisGestion { get; set; }
        public int NombreHeuresTotalRemboursees { get; set; }
        public string Etat { get; set; }
        public string NoteCredit { get; set; }
        public string Imputation { get; set; }
    }
    static void Main()
    {
        var ser = new XmlSerializer(typeof(ListeAvisRemboursements));
        var wrapper = (ListeAvisRemboursements)ser.Deserialize(new StringReader(xml));
        // inspect wrapper.Items etc
    }
