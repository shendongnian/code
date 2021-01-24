    public class ResponseModel
    {
        public string language { get; set; }
        public string textAngle { get; set; }
        public string orientation { get; set; }
        //you have to create pocco class for RegionModel
        public List<RegionModel> regions { get; set; }
        ....
    }
