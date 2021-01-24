     //Xaml
     <ListView x:Name="listview" IsGroupingEnabled="true">
        <ListView.GroupHeaderTemplate>
            <DataTemplate>
                <ViewCell>
                    <Label BackgroundColor="Pink"
                           HorizontalOptions="FillAndExpand"
                           Text="{Binding Name}" />
                </ViewCell>
            </DataTemplate>
        </ListView.GroupHeaderTemplate>
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <Label HorizontalTextAlignment="Center"
                           FontSize="Large" 
                           HorizontalOptions="FillAndExpand" 
                           Text="{Binding Name}" />
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    //Code
    public partial class Page2 : ContentPage
    {
        public Page2(object obj)
        {
            InitializeComponent();
            var person = obj as Person;
            listview.ItemsSource = person.List;
        }
    }
