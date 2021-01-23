    public bool IsDesignTime
    {
      get
      {
        return DesignerProperties.GetIsInDesignMode(Application.Current.RootVisual);
      }
    }
