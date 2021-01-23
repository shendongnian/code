    public class VehicleFeatureList : List<VehicleFeature>
    {
        public GlobalEnums.VehicleFeatureListType VehicleFeatureListType { get; set; }
        private List<VehicleFeature> values;
        public List<VehicleFeature> Values
        {
            get { return values; }
            set { values = value; }
        }
        public VehicleFeature this[int index]
        {
            get
            {
                return Values[index];
            }
            set
            {
                Values[index] = value; 
            }
        }
        public void Add(int ValueId)
        {
            this.values.Add(new VehicleFeature(ValueId, this.VehicleFeatureListType));
        }
        public VehicleFeatureList(GlobalEnums.VehicleFeatureListType vehicleFeatureListType)
        {
            this.VehicleFeatureListType = vehicleFeatureListType;
        }
    }
