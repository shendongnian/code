    public void M1()
    {
      var list = new List<Object>
        {
          1
        };
      Contract.Assume(Contract.ForAll(list, t => t != null));
      this.X(list); // Still gives warning on the ForAll requirement
    }
    public void X(ICollection<object> c)
    {
      Contract.Requires<ArgumentNullException>(c != null);
      Contract.Requires<ArgumentException>(Contract.ForAll(c, x => x != null));
    }
