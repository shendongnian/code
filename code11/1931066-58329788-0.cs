    public class Car
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public Engine engine { get; private set; }
        public Car(string name, string model, Engine engine)
        {
            this.name = name;
            this.model = model;
            this.engine = engine;
        }
    }
    class Engine
    {
        public string number { get; private set; }
        // other values as necessary
        public Engine(string number)
        {
            this.number = number;
        }
    }
    var newCar = new Car('Volvo', 'Hatchback', new Engine('someNumber'));
    var engineNumber = newCar.engine.number;
