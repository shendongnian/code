<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:App12"
             x:Name="myPage"
             x:Class="App12.MainPage">
    <StackLayout VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand" >
        <Image Source="OneD_Icon_Small.png" HorizontalOptions="StartAndExpand" Margin="5,5,0,0">
            <Image.GestureRecognizers>
                <TapGestureRecognizer Command="{Binding HomeCommand}"  CommandParameter="{Binding .,Source={x:Reference myPage}}" NumberOfTapsRequired="1" />
            </Image.GestureRecognizers>
        </Image>
    </StackLayout>
</ContentPage>
And in the ViewModel
public class TapViewModel : INotifyPropertyChanged
 {        
   ICommand homeCommand;
   public TapViewModel()
   {
      // configure the TapCommand with a method
      homeCommand = new Command(OnTapped);
   }
   public ICommand HomeCommand
   {
     get { return homeCommand; }
   }
   public event PropertyChangedEventHandler PropertyChanged;
   void OnTapped(object s)
   {
     var page = s as ContentPage;
     if (page.GetType() == typeof(MainPage))
     {
        //user on home page. Do nothing.
     }
     else
     {
        //navigate to Home.
     }
    }
        
}
**Note:**  object s is the contentPage ,and you can do something you want.
