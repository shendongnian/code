    public class SomeClass
    {
        public float KillPosX { get; set; }
        public float KillPosY { get; set; }
        public float KillPosT { get; set; }
        // Values are based on the related property values and cannot be set directly
        public bool KillX => !IsRoughlyZero(KillPosX);
        public bool KillY => !IsRoughlyZero(KillPosY);
        public bool KillT => !IsRoughlyZero(KillPosT);
        private static bool IsRoughlyZero(float input)
        {
            // Use a tolerance for comparing floating point numbers to 0
            return Math.Abs(input) < .0000001;
        }
    }
