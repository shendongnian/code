    static private Address GetAddress(Customer customer)
    {
         return customer.Address;
    }
    private class CityGetter
    {
        public string currentCity;
        public bool DoesCityMatch(Customer customer)
        {
            return customer.City == this.currentCity;
        }
    }
    ....
    var currentCityGetter = new CityGetter();
    currentCityGetter.currentCity = GetCurrentCity();
    var addresses = customers.Where(currentCityGetter.DoesCityMatch).Select(GetAddress);
