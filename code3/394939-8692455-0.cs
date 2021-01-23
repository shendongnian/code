    public static readonly DependencyProperty IsDragTargetProperty = DependencyProperty.RegisterAttached
            ("IsDragTarget", 
            typeof(bool), 
            typeof(TreeViewItemHeader),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    
    public Boolean IsDragTarget
      {
        get { return (Boolean)self.GetValue(IsDragTargetProperty ); }
        set { self.SetValue(IsDragTargetProperty , value); } 
      }
