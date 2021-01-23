    public static class RegionExtensions
    {
        public static int GetIdOrZero(this Region region)
        {
            return region == null ? 0 : region.Id;
        }
    }
