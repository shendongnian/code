     <AbsoluteLayout>
            <StackLayout
                Padding="5"
                AbsoluteLayout.LayoutBounds="0,0,1,1"
                AbsoluteLayout.LayoutFlags="All"
                BackgroundColor="White">
                <ListView
                    x:Name="cartView"
                    HasUnevenRows="True"
                    HorizontalOptions="FillAndExpand"
                    IsPullToRefreshEnabled="True"
                    ItemsSource="{Binding products}"
                    SeparatorColor="Black"
                    SeparatorVisibility="Default"
                    VerticalOptions="FillAndExpand">
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <ViewCell>
                                <StackLayout Orientation="Vertical">
                                    <Label
                                        x:Name="something"
                                        HorizontalOptions="CenterAndExpand"
                                        Text="{Binding ProductName}"
                                        TextColor="Black" />
                                    <Image
                                        HeightRequest="150"
                                        HorizontalOptions="CenterAndExpand"
                                        Source="{Binding ImgSource}"
                                        VerticalOptions="CenterAndExpand"
                                        WidthRequest="150" />
                                </StackLayout>
                            </ViewCell>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
                <Button
                    x:Name="getproduct"
                    Clicked="Getproduct_Clicked"
                    Text="load product" />
            </StackLayout>
            <StackLayout
                x:Name="LoadingOverlay"
                AbsoluteLayout.LayoutBounds="0,0,1,1"
                AbsoluteLayout.LayoutFlags="All"
                BackgroundColor="White"
                HorizontalOptions="FillAndExpand"
                IsVisible="{Binding loading}"
                Opacity="0.5"
                VerticalOptions="FillAndExpand">
                <ActivityIndicator
                    x:Name="TaskLoader"
                    HorizontalOptions="CenterAndExpand"
                    IsRunning="{Binding running}"
                    IsVisible="{Binding running}"
                    Scale="4"
                    VerticalOptions="CenterAndExpand"
                    Color="Red" />
            </StackLayout>
        </AbsoluteLayout>
      public partial class Page5 : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<product> products { get; set; }
        private bool _loading;
        public bool loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("loading");
            }
        }
        private bool _running;
        public bool running
        {
            get { return _running; }
            set
            {
                _running = value;
                RaisePropertyChanged("running");
            }
        }
        public Page5()
        {
            InitializeComponent();
            products = new ObservableCollection<product>();
            loading = false;
            running = false;
          
            this.BindingContext = this;
        }
        private void loaddata()
        {
            products.Add(new product() { ProductName = "product 1", ImgSource = "a5.jpg" });
            products.Add(new product() { ProductName = "product 2", ImgSource = "a6.jpg" });
            products.Add(new product() { ProductName = "product 3", ImgSource = "a7.jpg" });
            products.Add(new product() { ProductName = "product 4", ImgSource = "a8.jpg" });
            products.Add(new product() { ProductName = "product 1", ImgSource = "a5.jpg" });
            products.Add(new product() { ProductName = "product 2", ImgSource = "a6.jpg" });
            products.Add(new product() { ProductName = "product 3", ImgSource = "a7.jpg" });
            products.Add(new product() { ProductName = "product 4", ImgSource = "a8.jpg" });
        }
       
        public event PropertyChangedEventHandler PropertyChanged;   
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private async void Getproduct_Clicked(object sender, EventArgs e)
        {
            loading = true;
            running = true;
           
           await Task.Delay(5000);
            loaddata();
            loading = false;
            running = false;
        }
    }
    public class product
    {
        public string ProductName { get; set; }
        public string ImgSource { get; set; }
    }
