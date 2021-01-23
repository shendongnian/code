    namespace Vehicles
    {
      public class vehicle
      {
        public string Name;
      } // class
    } // namespace
    
    using Vehicles;
    namespace Cars
    {
      public class car: vehicle
      {
        public string Name;
    	public void Start() { ... }
      }  // class
    } // namespace
    
    using Vehicles;
    namespace Planes
    {
      public class plane: vehicle
      {
        public void Fly() { ... }
      }
    } 
