    public partial class Client
    {
        public ClientDemographic CurrentDemogaphic
        {
            get { return this.ClientDemographics.First(cd => cd.IsPrimary); }
        }
    }
