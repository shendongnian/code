    public class YoungPersonWithNewCarRule : Rule
    {
        public override void Define()
        {
            Person person = null;
            IEnumerable<Car> cars = null;
            When()
                .Match(() => person, p => p.Age < 30)
                .Let(() => cars, () => person.Cars.Where(c => c.Year > 2016))
                .Having(() => cars.Any());
            Then()
                .Yield(ctx => new YoungPersonWithNewCar(person, cars));
        }
    }
    public class YoungPersonWithNewCar
    {
        private readonly Car[] _cars;
        public Person Person { get; }
        public IEnumerable<Car> Cars => _cars;
        public YoungPersonWithNewCar(Person person, IEnumerable<Car> cars)
        {
            _cars = cars.ToArray();
            Person = person;
        }
    }
