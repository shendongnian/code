    public static readonly DependencyProperty IsDragTargetProperty = DependencyProperty.RegisterAttached
            ("IsDragTarget",
            typeof(bool),
            typeof(TreeViewItemHeader),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    
    public bool IsDragTarget {
                get { return (bool)this.GetValue(IsDragTargetProperty); }
                set { this.SetValue(IsDragTargetProperty, value); }
            }
