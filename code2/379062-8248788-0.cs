    public class VendorClass
    {
        public int VendorID {  get; set; }
        private string _vendorName;
        public string VendorName
        {
            get { return _vendorName; }
            set
            {
                if (value.Length > 15)
                {
                    _vendorName = value.Substring(0,15);                    
                } else { 
                    _vendorName = value;
                }
            }
        }
    }
