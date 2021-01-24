    public _ReturnType _PropertyName
    {
      get => Properties.TryGetValue<IMarkerInterface>(_string);
      set { Properties[_string] = value; }
    }
