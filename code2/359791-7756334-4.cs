    public class VehicleFeatureList : List<VehicleFeature>
    {
        public GlobalEnums.VehicleFeatureListType VehicleFeatureListType { get; set; }
        private List<VehicleFeature> values;
        public List<VehicleFeature> Values
        {
            get { return values; }
            set { values = value; }
        }
        public void Add(int ValueId)
        {
            this.values.Add(new VehicleFeature(ValueId, this.VehicleFeatureListType));
        }
        public void AddRange(int[] values)
        {
            foreach (int item in values)
            {
                this.Add(item);
            }
        }
        public VehicleFeatureList(GlobalEnums.VehicleFeatureListType vehicleFeatureListType)
        {
            this.VehicleFeatureListType = vehicleFeatureListType;
        }
    }
