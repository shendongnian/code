    public static readonly DependencyProperty EditorEnabledDependencyProperty = DependencyProperty.Register("EditorEnabled", typeof(bool), typeof(UcComponentEditor), new PropertyMetadata(false));
    
    public bool EditorEnabled
    {
        get { return (bool)base.GetValue(UcComponentEditor.EditorEnabledDependencyProperty); }
        set { base.SetValue(UcComponentEditor.EditorEnabledDependencyProperty, value); }
    }
