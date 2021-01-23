    public static class ColorsExtensions
    {
        public ColorTemp GetTemperature(this Colors color)
        {
            return (ColorTemp)(color & 0x01);
        }
    }
