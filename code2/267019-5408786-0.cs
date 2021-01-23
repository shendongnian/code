    public TreasureCard Clone()
    {
       return new TreasureCard
       {
          Name = this.Name,
          Type = this.Type,
          ...
       };
    }
