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
In Addition , When you set the Path of binding ,you have to set the BindingContext at same time .
For example , I binding the value of width to a slider .
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
Set the GridUnitType as Star will not lead crash .So if your issue is still appear, you can create a sample which contains the issue so that I can test it on my side .
