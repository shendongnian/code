    public class PersonelModel
    {
        public int pid { get; set; }
        public string pAd { get; set; }
        public string pSoyad { get; set; }
        public string yonetici { get; set; }
        public string Description
        {
            get
            {
                return pAd + " " + pSoyad;
            }
        }
    }
