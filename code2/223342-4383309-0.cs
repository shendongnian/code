    public void StartDateNotInPastSpecification : ISpecification<ISomeBusinessObject>
    {
      public bool IsSatisfiedBy(ISomeBusinessObject myBusinessObject)
      {
        return myBusinessObject.StartDate >= DateTime.Now;
      }
    }
