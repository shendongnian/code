    IQueryable<SubGroup> WhereAnyProductHasState(this IQueryable<SubGroup> subGroups, bool? state)
    {
        return subgroups.Where(subGroup => subGroup.Products.HasAnyWithState(state));
    }
    bool HasProductsWithState(this IQueryable<SubGroup> subGroups, bool? state)
    {
         return subGroups.WhereAnyProductHasState(state).Any();
    }
