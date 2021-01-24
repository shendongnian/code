<ListView x:Name="list1" ItemsSource="{Binding StudentList}">
<ListView.ItemTemplate >
    <DataTemplate>
        <ViewCell>
            <StackLayout>
                <Label VerticalTextAlignment="Center"  
                       Text="{Binding StudentName}" />
                <Button x:Name="mybtn"         
                    BindingContext="{Binding Source={x:Reference list1}, Path=BindingContext}" 
                    Command="{Binding BtnTextCommand}" 
                    CommandParameter="{Binding Source={x:Reference mybtn}}"  
                    Text="{Binding PresentBool, Converter={StaticResource PresentToString}}" />
            </StackLayout>                  
        </ViewCell>
    </DataTemplate>
</ListView.ItemTemplate>
</ListView>
Then create a new class that implements [IValueConverter](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.ivalueconverter?view=xamarin-forms) - 
public class PresentToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Present" : "Absent";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
To use it as a StaticResource as I have above, you'll need to include it in a relevant resource dictionary. You can put it on the Page/ContentView that this ListView is from - 
<ContentView>
    <ContentView.Resources>
        <PresentToString x:Key="PresentToString" />
    </ContentView.Resources>
    <ListView x:Name="list1" ... >
...
And that should be all! If your converter is in a difference namespace, you will have to add the xaml include to the Page/ContentView.
**EDIT**
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    var typedValue = (int)value;
    // Since ints are not nullable, we don't need to do a null check
    switch (typedValue)
    {
        case 1:
            return "P";
        case 2:
            return "L";
        // case 0 handled in default. Removed to avoid redundancy.
        default:
            return "A";
    }
}
