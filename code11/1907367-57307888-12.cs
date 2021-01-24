    class Plane{
      public string Registration { get; set; } //reg can be changed during plane life
      public int NumberOfEngines { get; private set; } //read only to the rest of the world, as the engine count doesn't change, but needs to be writable internally to this class so the property can be set
      public Plane(int numberOfEngines){ //make numberOfEngines a constructor parameter to force it to be filled in when the plane is constructed. Registration is unknown at time of manufacture
        NumberOfEngines = numberOfEngines;
      }
    }
