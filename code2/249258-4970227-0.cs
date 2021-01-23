    public static readonly DependencyProperty DepartmentProperty = DependencyProperty.Register("Department", typeof(string), typeof(KPI), new UIPropertyMetadata(null, DepartmentPropertyChanged));
    
    private static void DepartmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        
        }    
    public string Department
    {
        get { return (string)GetValue(DepartmentProperty); }
        set { SetValue(DepartmentProperty, value); }
    }
    
