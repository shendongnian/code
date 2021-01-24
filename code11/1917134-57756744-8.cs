    class CarDealer
    {
        public int iID { get; set; }
        public string name { get; set; }
    }
    class Garage
    {
        public int gID { get; set; }
        public string gname { get; set; }
        public int dealerID { get; set; }
    }
    class Repair
    {
        public int rID { get; set; }
        public DateTime date { get; set; }
        public double cost { get; set; }
        public int garageID { get; set; }
    }
