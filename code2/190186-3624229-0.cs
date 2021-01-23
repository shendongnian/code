    public class PowerStationMap : SubclassMap<PowerStation>
    {
        public PowerStationMap()
        {
            DiscriminatorValue((int)1);
            Map(x => x.ElectricityProduction);
        }
    }
