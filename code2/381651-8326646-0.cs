        **public** Photoset photoset {get;set;}
        **public** string stat{get;set;}
    }
    class Photoset
    {
       
        public string id { get; set; }
        public string primary { get; set; }
        public string owner { get; set; }
        public string ownername { get; set; }
        public **Photo[]** photo { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public int perpage { get; set; }
        public int pages { get; set; }
        public string total { get; set; }
    }
    class Photo
    {
        public string id { get; set; }
        public string secret { get; set; }
        public string server { get; set; }
        public int farm { get; set; }
        public string title { get; set; }
        public string isprimary { get; set; }
        
    }
