    public class Dtl
    {
        public int ProdID { get; set; }
        public int ProdPkgID { get; set; }
        public DateTime TrDT { get; set; }
        public int Qty { get; set; }
    }
    
    public class InvPhy
    {
        public int OpID { get; set; }
        //public object RtID { get; set; }
        public int AccID { get; set; }
        public int LocID { get; set; }
        public int DlvrLocID { get; set; }
        public int InvAccID { get; set; }
        public DateTime FscDt { get; set; }
        public DateTime TrDT { get; set; }
        public bool Schdl { get; set; }
        public int CntType { get; set; }
        public int DvcID { get; set; }
        public int SvcUID { get; set; }
        public List<Dtl> Dtls { get; set; }
    }
    
    public class RootObject
    {
        public List<InvPhy> InvPhy { get; set; }
    }
