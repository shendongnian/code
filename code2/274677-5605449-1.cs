    <DataGrid ItemsSource="{Binding}">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Prop1}" />
                <DataGridTextColumn Binding="{Binding Prop2}" />
            </DataGrid.Columns>
    </DataGrid>
    class Base
    {
    }
    class Derived1: Base
    {
        public string Prop1 { get; set; }
    }
    class Derived2: Base
    {
        public string Prop2 { get; set; }
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        this.DataContext = new List<Base>()
        {
            new Derived1(){Prop1 = "Hello"},
            new Derived2() {Prop2 = "World"}
        };
    }
