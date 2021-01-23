    class AppleRepository : FruitRepository<Apple>
    {
        public override AddEagerLoading(IQueryable<Apple> query)
        {
            return query.EagerLoad(x => x.AppleBrands);
        }
    }
