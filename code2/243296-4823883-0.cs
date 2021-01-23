    class Car {
        public bool CarProperty { get; set; }
        // regular constructor
        public Car() {
        }
        // "copy" constructor
        public Car(Car c) {
            CarProperty = c.CarProperty;
        }
    }
    class SuperCar : Car {
        public bool SuperCarProperty { get; set; }
        // regular constructor
        public SuperCar() {
        }
        // "copy" constructor
        public SuperCar(Car c) : base(c) {
            SuperCar sc = c as SuperCar;
            if(sc != null) {
                SuperCarProperty = sc.SuperCarProperty;
            }
        }
