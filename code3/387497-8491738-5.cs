    public string Error
    {
      //This is needed for model level validation to work
      get { throw new NotImplementedException(); }
    }
    public string this[string propertyName]
    {
      //This is needed for property level validation to work
      get { throw new NotImplementedException(); }
    }
