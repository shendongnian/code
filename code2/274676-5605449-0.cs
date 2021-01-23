    <ListView ItemsSource="{Binding}">
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding Prop1}" />
                <GridViewColumn DisplayMemberBinding="{Binding Prop2}" />
            </GridView>
        </ListView.View>
    </ListView>
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
