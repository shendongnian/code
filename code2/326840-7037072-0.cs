    class Location 
    {
        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; UpdateLocationKey(); }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; UpdateLocationKey(); }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; UpdateLocationKey(); }
        }
        private void UpdateLocationKey()
        {
            LocationKey = Country.GetHashCode() ^ City.GetHashCode() ^ Address.GetHashCode();
        }
        int LocationKey;
        …
    }
