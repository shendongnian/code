    public IList<PetitionSignature> GetByPetition(Petition p)
    {
        return _session.CreateCriteria(typeof(PetitionSignature))
            .Add(Restrictions.Eq("Petition", p))
            .AddOrder(Order.Desc("Id"))
            .List()
            .Cast<PetitionSignature>()
            .OrderBy(sig => sig.Date)
            .ToList();
    }
