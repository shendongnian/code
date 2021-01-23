    public ObservableCollection<TestFieldView> Fields
    {
        get { return (ObservableCollection<TestFieldView>)GetValue(FieldsProperty); }
        set { SetValue(FieldsProperty, value); }
    }
    
    public static readonly DependencyProperty FieldsProperty =
        DependencyProperty.Register("Fields", typeof(ObservableCollection<TestFieldView>), typeof(MainWindow),
        new UIPropertyMetadata(new ObservableCollection<TestFieldView>()));
