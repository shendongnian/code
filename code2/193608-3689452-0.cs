    public static readonly DependencyProperty AquariumGraphicProperty = DependencyProperty.Register(
      "AquariumGraphic",
      typeof(Uri),
      typeof(AquariumObject),
      new FrameworkPropertyMetadata(null,
          FrameworkPropertyMetadataOptions.AffectsRender, 
          new PropertyChangedCallback(OnUriChanged)
      )
    );
    public Uri AquariumGraphic
    {
      get { return (Uri)GetValue(AquariumGraphicProperty); }
      set { SetValue(AquariumGraphicProperty, value); }
    }
