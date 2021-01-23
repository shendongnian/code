    public void SetCategoryId(ICollection<TeamWork> Converted, ICollection<TeamWork> Sourced)
    {
        foreach(var categoryRule in CategoryRules)
           if(test(Converted, Sourced) != 0)
              Converted.First().CategoryId = Sourced.First().CategoryId = 1;
    }
