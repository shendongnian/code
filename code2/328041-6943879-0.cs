    public partial class Person
    {
        public IEnumerable<Car> Cars
        {
            get { return this.CarOwners.Select(c => c.Car); }
        }
    }
