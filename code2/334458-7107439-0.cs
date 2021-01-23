    public static class ColorsExtensions
    {
        public bool IsWarm(this Colors color)
        {
            return (color & 0x01) == 1;
        }
    }
