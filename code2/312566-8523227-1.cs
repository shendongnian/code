        public class TVFactory {
        
        public TV BuildTV(Brands thisKind) {
            TV newSet;
            
            switch (thisKind) {
                case Brands.Samsung :
                    Samsung aSamsungTV = new Samsung();
                    aSamsungTV.BacklightIntensity = double.MinVal;
                    aSamsungTV.AutoShutdownTime = 45;    //oops! I made a magic number. My bad
                    newSet = aSamsungTV;
                    SetAutoShutDownTime = new delegate (newSet.SetASDT);
                    break;
                . . .
            } // switch
        }
        
        //more build methods for setting specific parameters
        public TV BuildTV (Brands thisKind, string Size) { ... }
        
        // maybe you can pass in a set of properties to exactly control the construction.
        // returning a concrete class reference violates the spirit of object oriented programming 
        public Sony BuildSonyTV (...) {}
        
        public TV BuildTV (Brands thisKind, Dictionary buildParameters) { ... }
    }
        
    public class TV {
        public string Size { get; set; }
        public string ScreenType { get; set; }
        public double BackLightIntensity { get; set; }
        public int AutoShutdownTime { get; set; }
        
        //define delegates to get/set properties
        public delegate  int GetAutoShutDownTime ();
        public delegate void SetAutoShutDownTime (object obj);
    
        public virtual TurnOn ();
        public virtural TurnOff();
        
        // this method implemented by more than one concrete class, so I use that
        // as an excuse to declare it in my base.
        public virtual SomeSonyPhillipsOnlything () { throw new NotImplementedException("I don't do SonyPhillips stuff"); }
        
    }
        
    public class Samsung : TV {
        public Samsung() {
            // set the properties, delegates, etc. in the factory
            // that way if we ever get new properties we don't open umpteen TV concrete classes
            // to add it. We're only altering the TVFactory.
            // This demonstrates how a factory isolates code changes for object construction.
        }
        
        public override void TurnOn() { // do stuff }
        public override void TurnOn() { // do stuff }
        
        public void SamsungUniqueThing () { // do samsung unique stuff }
        
        internal void  SetASDT (int i) {
            AutoShutDownTime = i;
        }
    }
        
    // I like enumerations. 
    //   No worries about string gotchas
    //   we get intellense in Visual Studio
    //   has a documentation-y quality
    enum Brands {
        Sony
        ,Samsung
        ,Phillips
    }
