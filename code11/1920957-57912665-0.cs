C#
private ObservableCollection<String> myButtons;
public ObservableCollection<String> MyButtons
{
    get { return myButtons; }
    set
    {
        if (myButtons == null)
        {
            myButtons = value;
            OnPropertyChanged("MyButtons");
        }
    }
}
private void PopulateButtons()
{
    List<Button> buttonsToAdd = new List<Button>();
    foreach (var item in Options)
    {
        buttonsToAdd.Add(item + "1");
    }
    MyButtons = new ObservableCollection<String>(buttonsToAdd);
}
In the DataTemplate, the DataContext will be the list item being displayed. That's a string now instead of a Button (but remember, the template was being ignored with the Buttons anyway). So to bind to the DataContext itself, just use `{Binding}`, with no path to a property of the DataContext. 
XAML
<ItemsControl.ItemTemplate>
    <DataTemplate>
        <Button 
            Command="{Binding Create_Click}" 
            CommandParameter="{Binding}" 
            Content="{Binding}">
            <Button.Style>
                <Style TargetType="Button" BasedOn="{StaticResource NiceStyleButton}">
                    <Setter Property="HorizontalAlignment" Value="Center"/>
                    <Setter Property="VerticalAlignment" Value="Center"/>
                    <Setter Property="Margin" Value="20"/>
                    <Setter Property="Padding" Value="6"/>
                    <Setter Property="FontSize" Value="42"/>
                </Style>
            </Button.Style>
        </Button>
    </DataTemplate>
</ItemsControl.ItemTemplate>
