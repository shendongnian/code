      <ListView ItemSelected="ListView_ItemSelectedAsync" ItemsSource="{Binding items}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Id}" />
                                <Label Text="{Binding Name}" />
                            </StackLayout>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page20 : ContentPage
	{
        public ObservableCollection<TodoItem1> items { get; set; }
		public Page20 ()
		{
			InitializeComponent ();
            items = new ObservableCollection<TodoItem1>()
            {
                new TodoItem1(){Id=1,Name="aaa"},
                new TodoItem1(){Id=2,Name="bbb"},
                new TodoItem1(){Id=3,Name="ccc"},
                new TodoItem1(){Id=4,Name="ddd"},
                new TodoItem1(){Id=5,Name="eee"},
                new TodoItem1(){Id=6,Name="fff"},
                new TodoItem1(){Id=7,Name="ggg"},
                new TodoItem1(){Id=8,Name="hhh"}
            };
            this.BindingContext = this;
		}
      
        private async void ListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new Page21 {BindingContext=e.SelectedItem as TodoItem1 });
        }
    }
    public class TodoItem1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
