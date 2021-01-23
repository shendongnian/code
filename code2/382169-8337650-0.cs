    public static class Extension
    {
        public static double ToRadians(this double degree)
        {
            return degree * Math.PI / 180;
        }
        public static double ToDegrees(this double val, bool radians = true)
        {
            return (radians == true) ? val * 180 / Math.PI : val * Math.PI / 180;
        }
    }
