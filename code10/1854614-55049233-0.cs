    public class Site
    {
        public int facility_id { get; set; }
        public string facility_name { get; set; }
        public string facility_code { get; set; }
        public string facility_DataValueField
        {
            get
            {
                return facility_id + ";" + facility_name + ";" + facility_code;
            }
        }
    }
