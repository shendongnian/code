     <StackLayout x:Name="gridFollowers" BindableLayout.ItemsSource="{Binding models}">
            <BindableLayout.ItemTemplate>
                <DataTemplate>
                    <Grid WidthRequest="75">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="8*" />
                            <RowDefinition Height="2*" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="7.5*" />
                        </Grid.ColumnDefinitions>
                        <Grid
                            Grid.Row="0"
                            Grid.Column="0"
                            WidthRequest="{Binding Height, Source={x:Reference headerImage}}">
                            <ffimageloading:CachedImage x:Name="headerImage" Source="{Binding image}" />
                        </Grid>
                        <Label
                            Grid.Row="1"
                            Grid.Column="0"
                            Text="{Binding firstname}" />
                    </Grid>
                </DataTemplate>
            </BindableLayout.ItemTemplate>
        </StackLayout>
         public partial class Page8 : ContentPage
	     {
        public ObservableCollection<imagemodel> models { get; set; }
		public Page8 ()
		{
			InitializeComponent ();
            models = new ObservableCollection<imagemodel>()
            {
                new imagemodel(){firstname="first image", image="a1.jpg"},
                new imagemodel(){firstname="second image",image="a2.jpg"}
            };
            this.BindingContext = this;
		}
	     }
        public class imagemodel
        {
        public string firstname { get; set; }
        public string image { get; set; }
        }
