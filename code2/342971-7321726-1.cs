    public class Engine
    {
       public int HorsePower {get;set;}
    }
    public class Vehicle
    {
        public Vehicle() { }
        public Engine Engine;
        public int Doors;
    }
    public class Airplane : Vehicle
    {
        public Airplane () { }
        public string PropellerModel;
    }
    public class Boat : Vehicle
    {
        public Boat () { }
        public string RudderModel;
    }
