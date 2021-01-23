    using System;
    namespace CustomEvents
    {
      public class Car
      {
        public delegate void OwnerChangedEventHandler(string newOwner);
        public event OwnerChangedEventHandler OwnerChanged;
    
        private string make;
        private string model;
        private int year;
        private string owner;
    
        public string CarMake
        {
          get { return this.make; }
          set { this.make = value; }
        }
    
        public string CarModel
        {
          get { return this.model; }
          set { this.model = value; }
        }
    
        public int CarYear
        {
          get { return this.year; }
          set { this.year = value; }
        }
    
        public string CarOwner
        {
          get { return this.owner; }
          set
          {
            this.owner = value;
            // To avoid race condition
            var ownerchanged = this.OwnerChanged;
            if (ownerchanged != null)
              ownerchanged(value);
          }
        }
        public Car()
        {
        }
      }
    }
