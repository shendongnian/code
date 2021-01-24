XAML
<StackLayout x:Name="baseLayout" Orientation="Horizontal" BackgroundColor="#EBEBEB" HeightRequest="130" 
                BindableLayout.ItemsSource="{Binding cardDatas}" WidthRequest="410">
    <BindableLayout.ItemTemplate>
        <DataTemplate>
            <StackLayout HeightRequest="300" VerticalOptions="Start" Orientation="Vertical">
                <Frame CornerRadius="0" 
                            HorizontalOptions="Start" 
                            VerticalOptions="Start" 
                            Margin="0"
                            Padding="0"
                            WidthRequest="410"
                            HeightRequest="80"
                            BackgroundColor="Red"
                            HasShadow="true">
                    <StackLayout Orientation="Vertical">
                        <Label Text="{Binding BindingContext.bUser.FirstName, Source={x:Reference baseLayout}}"/>
                        <Label Text="{Binding BindingContext.bUser.LastName, Source={x:Reference baseLayout}}"/>
                    </StackLayout>
                </Frame>
                <StackLayout Orientation="Vertical" BackgroundColor="Blue">
                    <ListView  ItemsSource="{Binding BindingContext.cardDatas, Source={x:Reference baseLayout}}">
                        <ListView.ItemTemplate>
                            <DataTemplate>
                                <ViewCell>
                                    <Label Text ="{Binding CardName}"/>
                                </ViewCell>
                            </DataTemplate>
                        </ListView.ItemTemplate>
                    </ListView>
                </StackLayout>
            </StackLayout>
        </DataTemplate>
    </BindableLayout.ItemTemplate>
</StackLayout>
And the model and view model class based on your codes,
c#
public class User
{
    public int Uid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class CardData
{
    public int _id { get; set; }
    public string CardName { get; set; }
    public string CardNote { get; set; }
}
public class BindingUser
{
    public User bUser { get; set; }
    public ObservableCollection<CardData> cardDatas { get; set; }
    public BindingUser()
    {
        cardDatas = new ObservableCollection<CardData>()
        {
            new CardData()
            {
                _id = 1,
                    CardName = "Testing1",
                    CardNote = "Test data1",
            },
            new CardData()
            {
                _id = 2,
                    CardName = "Testing2",
                    CardNote = "Test data2",
            },
            new CardData()
            {
                _id = 3,
                    CardName = "Testing3",
                    CardNote = "Test data3",
            },
        };
        bUser = new User
        {
            Uid = 23432,
            FirstName = "First User",
            LastName = "Last User",
        };
    }
}
