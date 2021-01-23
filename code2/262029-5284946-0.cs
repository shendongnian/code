    public IEnumerable<UserBandRelation> GetBandRelationsByUser(
        Expression<Func<UsersBand, bool>> predicate)
    {
        using (var ctx = new OpenGroovesEntities())
        {
            var relations = ctx.UsersBands.Where(predicate);
    
            // mapping, other stuff, back to business layer
            return relations.ToList();
        }
    }
