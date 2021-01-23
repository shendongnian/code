public IQueryable<Models.Estate> GetEstates() {
    return from e in entity.Estates.AsEnumerable()
           let AllCommFeat = from f in entity.CommunityFeatures
                             select new CommunityFeatures {
                                 Name = f.CommunityFeature1,
                                 CommunityFeatureId = f.CommunityFeatureId
                             },
           let AllHomeFeat = from f in entity.HomeFeatures
                             select new HomeFeatures() {
                                 Name = f.HomeFeature1,
                                 HomeFeatureId = f.HomeFeatureId
                             },
           select new Models.Estate {
                EstateId = e.EstateId,
                AllHomeFeatures = new LazyList<HomeFeatures>(AllHomeFeat),
                AllCommunityFeatures = new LazyList<CommunityFeatures>(AllCommFeat)
           };
}
