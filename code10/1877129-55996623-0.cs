    public class Car
    {
        // Member fields should be either "_camelCase" or "camelCase"
        private string _make;
        private string _model;
        private int _year;
        private int _speed;
        // Don't duplicate the code, default value for speed makes it optional parameter. 
        // There is no need for a second constructor.
        public Car(string make, string model, int year, int speed = 0)
        {
            _make = make;
            _model = model;
            _year = year;
            _speed = speed;
        }
        public int SpeedUp()
        {
            // Increments speed and returns the value.
            // Might as well be void without return since example doesn't use it anywhere.
            return _speed++;
        }
        public int SlowDown()
        {
            // If speed is more than 1, decrement and then return the value
            return _speed > 0 ? _speed-- : 0;
        }
        public void Display()
        {
            // String interpolations are much easier to read
            Console.WriteLine($"{_year} {_make} {_model} is going {_speed} MPH.");
        }
    }
    public class Program
    {
        // Main is entry point for your app, it doesn't belong in any type class like Car, 
        // because it's not relevant to it
        private static void Main()
        {
            // Use descriptive names for variables, you already know one car is Ford and the 
            // other is Chevy so name them as such so you know which is which
            // later in the code. 
            var fordCar = new Car("Ford", "Focus", 2010, 20);
            var chevyCar = new Car("Chevy", "Cruze", 2018); // No speed parameter
            // Ommited variables car1Speed, car2Speed. You shouldn't declare variables 
            // that serve no purpose and aren't even in use.
            for (int i = 0; i < 60; i++)
            {
                if (i % 2 == 0)
                {
                    // Returns int, but variable assignment ins't necessary to anything here
                    chevyCar.SpeedUp(); 
                }
                if (i % 3 == 0)
                {
                    fordCar.SpeedUp();
                }
                if (i % 5 == 0)
                {
                    fordCar.SlowDown();
                    chevyCar.SlowDown();
                }
            }
            fordCar.Display();
            chevyCar.Display();
        }
    }
