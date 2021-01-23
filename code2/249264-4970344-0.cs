    public static readonly DependencyProperty DepartmentProperty = DependencyProperty.Register
       (
           "Department", 
            typeof(string), 
            typeof(KPI), 
            new UIPropertyMetadata(null, OnDepartmentChanged));
    public string Department
    {
        get { return (string)GetValue(DepartmentProperty); }
        set { SetValue(DepartmentProperty, value);}
    }
    static void OnDepartmentChanged(DependencyObject d, 
                                    DependencyPropertyChangedEventArgs e)
    {
         (d as KPI).DataModified  = true; //this is all you want!
    }
