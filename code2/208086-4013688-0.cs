    class Vehicle { public void Drive(); }
    class Boat : Vehicle { public void LowerAnchor(); }
    class Car : Vehicle { public void SoundHorn(); }
    Vehicle boat = new Boat();
    boat.Drive();
    Vehicle car = new Car();
    car.Drive();
