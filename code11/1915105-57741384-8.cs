    public class BuildSearch
    {
        //Bootstrap date entry
        public DateTime StartDate { get; set; }
        //Bootstrap date entry
        public DateTime EndDate { get; set; }
        public int GeoAreaId { get; set; } //added field
        //Need this bound to a radio button list
        public List<GeoArea> GeoAreas { get; set; }
        public BuildSearch()
        {
            GeoAreas = new List<GeoArea>();
            //   StartDate = DateTime.Parse(DateTime.Now.AddDays(-31).ToShortDateString());
            //  EndDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            GeoAreas.Add(new GeoArea { GeoAreaItem = "Region", Id = 0 });
            GeoAreas.Add(new GeoArea { GeoAreaItem = "Manager1", Id = 1 });
            GeoAreas.Add(new GeoArea { GeoAreaItem = "Manager2", Id = 2 });
        }
        public class GeoArea
        {
            public int Id { get; set; }
            public string GeoAreaItem { get; set; }
        }
    }
