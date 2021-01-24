                        <Label Grid.Column="0" Text="Id" />
                        <Label Grid.Column="1" Text="First Name" />
                        <Label Grid.Column="2" Text="Surname" />
                        <Label Grid.Column="3" Text="Date Of Birth" />
                    </Grid>
                </ListView.Header>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                </Grid.RowDefinitions>
                                <Label Grid.Column="0" Text="{Binding Id}" />
                                <Label Grid.Column="1" Text="{Binding FirstName}" />
                                <Label Grid.Column="2" Text="{Binding Surname}" />
                                <Label Grid.Column="3" Text="{Binding Age}" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
            <Button
                x:Name="btn"
                Clicked="Btn_Clicked"
                Text=" Load more items" />
        </StackLayout>
    public partial class Page6 : ContentPage
	{
        public PersonViewModel p { get; set; }
		public Page6 ()
		{
			InitializeComponent ();
            p = new PersonViewModel();
            this.BindingContext = p;
            
        }      
        private void Btn_Clicked(object sender, EventArgs e)
        {
            personmodel model = p.peoples.Last();
            Device.BeginInvokeOnMainThread(() =>
          listView.ScrollTo(model, ScrollToPosition.End, true));
        }
    }
    public class PersonViewModel
    {
        public ObservableCollection<personmodel> peoples { get; set; }
       
        public PersonViewModel()
        {
            peoples = new ObservableCollection<personmodel>();
          for(int i=0;i<50;i++)
            {
                peoples.Add(new personmodel() { Id="the "+ i +" item",FirstName="cherry",Surname="Bu",Age=28});
            }
           
                    
        }
    }
