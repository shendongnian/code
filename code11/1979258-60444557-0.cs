   <Button Grid.Column="2" Text="More" VerticalOptions="StartAndExpand" Command="{ Binding BindingContext.GetIdCommand, Source={x:Reference Name=BillView} }"  CommandParameter="{Binding .}"  />
Here is layout code.
        <StackLayout Padding="10">
            <Label x:Name="header" FontSize="25" Text="Invoices" 
           HorizontalOptions="Center" VerticalOptions="CenterAndExpand"
            />
            <ListView x:Name="BillView" ItemsSource="{Binding Bills}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                            <Label YAlign="Center" x:Name="MyInvoiceNumber" XAlign="Center" Grid.Column="0" Text="{Binding InvoiceNumber}" />
                                <Label YAlign="Center" XAlign="Center" Grid.Column="1" Text="{Binding InvoiceDate}" />
                          
                            <Button Grid.Column="2" Text="More" VerticalOptions="StartAndExpand" Command="{ Binding BindingContext.GetIdCommand, Source={x:Reference Name=BillView} }"  CommandParameter="{Binding .}"  />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
Here is layout background code.
     public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MyBillViewModel(Navigation);
        }
    }
Here is `MyBillViewModel`.
      public class MyBillViewModel
    {
        public ICommand GetIdCommand { protected set; get; }
        public ObservableCollection<Bill> Bills { get; set; }
        public INavigation Navigation { get; set; }
        public MyBillViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Bills = new ObservableCollection<Bill>();
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "1" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "2" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "3" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "4" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "5" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "6" });
            Bills.Add(new Bill { InvoiceDate = "2020/2/23", InvoiceNumber = "7" });
            GetIdCommand = new Command<Bill>(async (key) => {
                Bill bill=(Bill)key;
                await Navigation.PushAsync(new Page2(bill));
                
            });
         }
    }
Here is `Bill` mode.
        public class Bill
    {
        public  string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
    }
 
Here is my running GIF.
[![enter image description here][1]][1]
I update my demo to github, you can refer to it.
https://github.com/851265601/FormsListviewCommand
  [1]: https://i.stack.imgur.com/6yWhr.gif
