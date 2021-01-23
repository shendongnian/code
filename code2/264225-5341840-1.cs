    public void SetCategoryId(ICollection<TeamWork> Converted, ICollection<TeamWork> Sourced)
    {
        foreach(var categoryRule in CategoryRules)
        {
           var category = test(Converted, Sourced);
           if(category != 0)
           {
              Converted.First().CategoryId = Sourced.First().CategoryId = category;
              break;
           }
        }
    }
