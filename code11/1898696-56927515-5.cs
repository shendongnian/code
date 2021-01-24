//
// Summary:
//     Interpret the Xamarin.Forms.GridLength.Value property value as a proportional
//     weight, to be laid out after rows and columns with Xamarin.Forms.GridUnitType.Absolute
//     or Xamarin.Forms.GridUnitType.Auto are accounted for.
//
// Remarks:
//     After all the rows and columns of type Xamarin.Forms.GridUnitType.Absolute and
//     Xamarin.Forms.GridUnitType.Auto are laid out, each of the corresponding remaining
//     rows or columns, which are of type Xamarin.Forms.GridUnitType.Star, receive a
//     fraction of the remaining available space. This fraction is determined by dividing
//     each row's or column's Xamarin.Forms.GridLength.Value property value by the sum
//     of all the row or column Xamarin.Forms.GridLength.Value property values, correspondingly,
//     including its own.
Star = 1,
In addition, when you set the `Binding Path`, you have to set the `BindingContext` at the same time.
For example, I am binding the value of width to a slider.
<ContentPage.Content>
  <StackLayout>
     <Slider x:Name="slider" Maximum="200" Minimum="100" Value="100" />
     <Grid  Grid.Column="1" ColumnSpacing="0">
        <Grid.ColumnDefinitions>
             <ColumnDefinition BindingContext="{x:Reference slider}"  Width="{Binding Path=Value, Mode=TwoWay, Converter={StaticResource numberToGridLengthConverter}}" />
             <ColumnDefinition BindingContext="{x:Reference slider}"  Width="{Binding Path=Value, Mode=TwoWay, Converter={StaticResource numberToGridLengthConverter}}" />
        </Grid.ColumnDefinitions>
        <BoxView Grid.Column="0" BackgroundColor="LightGreen" HorizontalOptions="FillAndExpand" HeightRequest="20" />
        <BoxView Grid.Column="1" BackgroundColor="Orange" HorizontalOptions="FillAndExpand" HeightRequest="20" />
    </Grid>
  </StackLayout>
</ContentPage.Content>
Setting the `GridUnitType` to `Star` will not lead to a crash. So if your issue is still appearing, you can create a sample which contains the issue, so that I can test it on my side .
#**Update:**
I have found your issue!
You should Initialize the **MovementCalm** and **MovementRapid** in the the constructor .
public StatisticsViewModel()
{
  SetMovement();
}
in your contentpage (such as MainPage)
public MainPage()
{
  InitializeComponent();
  BindingContext = new StatisticsViewModel();
}
The method **OnAppearing** and **OnDisappearing** will never been called because the ViewModel is not a **ContentPage** .
So the value of width is always **0** .When set the **GridUnitType** as **Star** it will crash . But when you set it as **Absolute** it won't because  Absolute allows value as **0** .
 
