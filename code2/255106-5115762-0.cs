    public static class RegionManagerExtensions
    {
        public static void RequestNavigateEx(this IRegionManager regionManager, String regionName, Uri source)
        {
            if (regionManager != null)
            {
                IRegion region = regionManager.Regions[regionName];
                if (region != null)
                {
                    foreach (Object view in region.ActiveViews)
                    {
                        region.Remove(view);
                    }
                    regionManager.RequestNavigate(regionName, source);
                }
            }
        }
    }
