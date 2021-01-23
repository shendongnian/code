    public static readonly DependencyProperty DepartmentProperty =
        DependencyProperty.Register("Department",
                                    typeof(string),
                                    typeof(KPI),
                                    new UIPropertyMetadata(null, DepartmentPropertyChanged));
    
    private static void DepartmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Talk to your Business/Data layers here
    }    
    public string Department
    {
        get { return (string)GetValue(DepartmentProperty); }
        set { SetValue(DepartmentProperty, value); }
    }
