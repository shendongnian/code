    public class Provider_Coupon_FullViewModel
    {
        public int pid { get; set; }
        public int cid { get; set; }
        public int crid { get; set; }
        public string opr_user { get; set; }
        public List<PackageDetailsViewModel> PackageDetails { get; set; }
    }
    public class PackageDetailsViewModel
    {
        public int packages_id { get; set; }
        public string package_title { get; set; }
        public bool is_selected { get; set; } /////// <--- BOOL PROPERTY <--- ///////
    }
