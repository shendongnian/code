    public Car(String cName, double cMaxSpeed, transmission cTransmission, bodystyle cBodystyle, carcolors cColors, fueltype cFueltype) {
             carname = cName;
             transmission = cTransmission;
             bodystyle = cBodystyle;
             colors = cColors;
             fueltype = cFueltype;
             maxspeed = cMaxSpeed;
         }
    
         public transmission transmission
         {
             get;
             private set;
         }
         public bodystyle bodystyle
         {
             get;
             private set;
         }
         public carcolors colors
         {
             get;
             private set;
         }
         public fueltype fueltype
         {
             get;
             private set;
         }
