    class Me : IHaveCar
    {
        BuickCentury myCentury = new BuickCentury(2004);
        
        public Car Car { get { return myCentury; } }
        
        public void Drive()
        {
            myCentury.CruiseWithAuthority();
        }
    }
    
    class EvilOilChangeService
    {
        public void ChangeOil(IHaveCar customer)
        {
            Car car = customer.Car;
            // here's the fictional "replace object in memory" operator
            car <<== new VolkswagenBeetle(2003);
        }
    }
