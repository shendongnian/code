C#
public class ViewModel : ViewModelBase
{
    public Dictionary<int, Tuple<int, int>> RowColumnOptions 
        => SystemSettingsSingleton.RowColumnOptions;
    private void PopulateButtons()
    {
        OnPropertyChanged(nameof(RowColumnOptions));
    }
    //  I don't know what your relay command class looks like, I just tossed one 
    //  together that has an Action<object>
    public ICommand Create_Click { get; } = new RelayCommand(param =>
    {
        var tuple = param as Tuple<int, int>;
        MessageBox.Show($"Parameter: {tuple.Item1} x {tuple.Item2}");
    });
}
And the ItemsControl:
XAML
<ItemsControl ItemsSource="{Binding RowColumnOptions}">
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <!-- 
            The DataContext here is a KeyValuePair<int, Tuple<int, int>> 
            
            The product of x * y was the Key, so that's what we'll display in the button's 
            Content. 
            
            We could display all three values if we wanted to. 
            
            We want to pass the tuple to the command, and that's the Value of the KeyValuePair. 
            So we bind that to CommandParameter
            -->
            <Button 
                Command="{Binding DataContext.Create_Click, RelativeSource={RelativeSource AncestorType=ItemsControl}}" 
                CommandParameter="{Binding Value}" 
                Content="{Binding Key}"
                >
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
</ItemsControl>
Some questions linger in my mind: What if you have both "`2x6"` and `"3x4"` in that initial list of options? The first one that comes in will be replaced by the second. Is that the desired behavior? 
