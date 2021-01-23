    interface IDrivable {
      void Drive();
    }
    
    interface IFlyable {
      void Fly();
    }
    
    class Car : IDrivable {
      public void Drive() { /* Implementation */ }
    }
    
    class Plane : IFlyable {
      public void Fly() { /* Implementation */ }
    }
    
    class MyClass : IDrivable, IFlyable {
      private IDrivable _car = new Car();
      private IFlyable _plane = new Plane();
    
      public void Drive() { _car.Drive(); }
      public void Fly() { _plane.Fly(); }
    }
