       <StackLayout>
            <ListView ItemsSource="{Binding model3s}" ItemTapped="ListView_ItemTapped">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Id}" />
                                <Label Text="{Binding FirstName}" />
                                <Label Text="{Binding LastName}" />
                            </StackLayout>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    public partial class Page11 : ContentPage
	{
        public ObservableCollection<model3> model3s { get; set; }
		public Page11 ()
		{
			InitializeComponent ();
            model3s = new ObservableCollection<model3>()
            {
                new model3(){Id=1,FirstName="Cherry",LastName="Bu",Description="Age is 28, class is A"},
                new model3(){Id=2,FirstName="Barry",LastName="Bu",Description="Age is 32, class is B"},
                new model3(){Id=3,FirstName="Wendy",LastName="Bu",Description="Age is 25, class is C"},
                new model3(){Id=4,FirstName="Stnfan",LastName="Bu",Description="Age is 27, class is A"},
                new model3(){Id=5,FirstName="Annie",LastName="Bu",Description="Age is 28, class is B"},
                new model3(){Id=6,FirstName="Mattew",LastName="Bu",Description="Age is 25, class is C"},
                new model3(){Id=7,FirstName="Amy",LastName="Bu",Description="Age is 29, class is A"},
                new model3(){Id=8,FirstName="Elvis",LastName="Bu",Description="Age is 32, class is B"},
            };
            this.BindingContext = this;
		}
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as model3;
            await Navigation.PushModalAsync(new Page12(content));
        }
    }
    public class model3
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
    }
