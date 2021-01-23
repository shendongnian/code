    public void Problem(Guid optional = new Guid())
    {
      // when called without parameters this will be true
      var guidIsEmpty = optional == Guid.Empty;
    }
