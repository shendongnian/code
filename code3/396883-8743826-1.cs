    [Serializable]
    public sealed class RecentAssetList
    {
        private List<int> assets = new List<int>();
        public List<int> RecentAssets 
        {
            get { return this.assets; }
        }
    }
    public static RecentAssetList RecentAssetList
    {
        get
        {
            var session = HttpContext.Current.Session;
            var assetlist = session["RECENT_ASSET_LIST"];
            return (RecentAssetList)assetlist;
        }
    }
