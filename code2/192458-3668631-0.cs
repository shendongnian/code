    public void SetRoles(Enums.Roles role)
    {
      List<string> result = new List<string>();
      foreach(Roles r in Enum.GetValues(typeof(Roles))
      {
        if ((role & r) != 0) result.Add(r.ToString());
      }
    }
