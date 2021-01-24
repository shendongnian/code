    <StackLayout>
            <ListView x:Name="listview1" ItemsSource="{Binding collection}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding FirstName}" />
                                <Label Text="{Binding LastName}" />
                                <Label Text="{Binding Description}" />
                            </StackLayout>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    public partial class Page12 : ContentPage
	{
       public ObservableCollection<model3> collection { get; set; }
        
        public Page12 (model3 content)           
		{
			InitializeComponent ();
            collection = new ObservableCollection<model3>();
            collection.Add(content);
            
            this.BindingContext = this;
		}
	}
