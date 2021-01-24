    public class SomeClass
    {
        public float KillPosX { get; set; }
        public float KillPosY { get; set; }
        public float KillPosT { get; set; }
        // Use a tolerance for comparing floating point numbers to 0
        public bool KillX => Math.Abs(KillPosX) > .0001;  
        public bool KillY => Math.Abs(KillPosY) > .0001;
        public bool KillT => Math.Abs(KillPosT) > .0001;
    }
