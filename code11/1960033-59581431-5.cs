       public class Prijem
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int BCode { get; set; }
        public string Name { get; set; }
        public string FirmName { get; set; }
        public string ItemCode { get; set; }
        public string Count { get; set; }
        string image = " Image";
        public string MyImage
        {
            set
            {
                if (image != value)
                {
                    image = value;
                   
                }
            }
            get
            {
                return image;
            }
        }
       
    }
