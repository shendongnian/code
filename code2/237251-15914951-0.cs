    [Story(AsA = "car manufacturer",
           IWant = "a factory that makes the right cars",
           SoThat = "I can make money")]
    public class when_building_a_toyota : Specification
    {
        static CarFactory _factory;
        static Car _car;
    
        given a_car_factory = () =>
                                  {
                                      _factory = new CarFactory();
                                  };
    
        when building_a_toyota = () => _car = _factory.Make(CarType.Toyota);
    
        [then]
        public void it_should_create_a_car()
        {
            _car.ShouldNotBeNull();
        }
    
        [then]
        public void it_should_be_the_right_type_of_car()
        {
            _car.Type.ShouldEqual(CarType.Toyota);
        }
    }
