    public class Plant
    {
        public Guid PlantID { get; set; }
        public virtual License License { get; set; }
    } 
    
    public class License
    {
         // No need to have a PlantID foreign key since the foreign key.
         public Guid LicenseID { get; set; }
         public virtual Plant Plant { get; set; }
    }
