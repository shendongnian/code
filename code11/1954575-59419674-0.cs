    public class NPPR_Provider : Provider
    {
        public int NPPR_ProviderId { get; set; }
        public NPPR_Header NPPR_Header { get; set; }
        public NPPR_ServLocation NPPR_ServLocation { get; set; }
        … // data properties here
    }
    public class NPPR_Header {
        public int NPPR_HeaderId {get;set;}
        public int NPPR_ProviderId {get;set;}
        public NPPR_Provider {get;set;}
        … // data properties here
    }
    public class NPPR_ServLocation { 
        public int NPPR_ServLocationId {get;set;}
        public int NPPR_ProviderId {get;set;}
        public NPPR_Provider {get;set;}
        … // data properties here.
    }
