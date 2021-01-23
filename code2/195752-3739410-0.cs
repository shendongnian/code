    class StickShiftCar : Car
    {
        public int MilesPerHour
        {
            get {return this._milesPerHour;}
     
            set 
            {
              if (vaule < 20)
                  this._gearPosition = 1;
              else if (value > 30)
                  this._gearPosition = 2;
              ...
              ...
              this._milesPerHour = value;
      }
    }
