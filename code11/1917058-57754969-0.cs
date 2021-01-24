    namespace ProLimb.Models
    {
        public class RegionModel
        {
            public string Continent { get; set; }
            public string Country { get; set; }
        }
    
        //TRYING TO GET TO WORK
        Regions = string.Join("; ", lstRegions.SelectedItems.OfType<RegionModel>().Select(x => x.Continent));
    }
