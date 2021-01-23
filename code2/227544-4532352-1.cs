    <toolkit:ListPicker x:Name="WeekStartDay"
                        Header="Week begins on"
                        Loaded="WeekStartDay_Loaded">
        <sys:String>monday</sys:String>
        <sys:String>sunday</sys:String>
    </toolkit:ListPicker>
    private void WeekStartDay_Loaded(object sender, RoutedEventArgs e)
    {
        Binding binding = new Binding();
        binding.Source = this.Resources["AppSettings"] as ApplicationSettings;
        binding.Path = new PropertyPath("WeekBeginsSetting");
        binding.Mode = BindingMode.TwoWay;
        WeekStartDay.SetBinding(ListPicker.SelectedItemProperty, binding);
    }
