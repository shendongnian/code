    namespace Vehicles
    {
      public class vehicle {
        public string Name;
       
        public virtual CopyFrom (vehicle Source)
        {
          this.Name = Source.Name;
          // other fields
        }
      } // class
    
    } // namespace 
