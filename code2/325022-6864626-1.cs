    class Participant {
      public PhysicalDetailsType PhysicalDetails { get; set; }
      public List<PhysicalFeatureType> PhysicalFeatures {
        get { return PhysicalDetails.PhysicalFeatures; }
        set { Physicaldetails.PhysicalFeatures = value; }
      }
    }
