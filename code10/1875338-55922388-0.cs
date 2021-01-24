<Button
    Text="{Binding Name}"
    TextColor="White"
    Command="{Binding ToggleCommand}"
    ContentLayout="Top"
    BackgroundColor="Transparent"
    BorderColor="White"
    BorderWidth="2"
    CornerRadius="6"
    Margin="5,5,5,10" >
    <Button.Triggers>
        <DataTrigger
            TargetType="Button"
            Binding="{Binding IsToggled}"
            Value="True">
            <Setter Property="BackgroundColor" Value="Blue" />
        </DataTrigger>
    </Button.Triggers>
</Button>
Also, as shown above, I would suggest putting an `ICommand` property in your Category class to execute the changing of the bool property.
The Command/Code for the **Category** model object would look like such:
//Constructor
public Category()
{
    ToggleCommand = new Command(() =>
    {
        IsToggled = !IsToggled;
        NotifyPropertyChanged(nameof(IsToggled));
    };
}
public ICommand ToggleCommand { get; }
public bool IsToggled { get; set; }
Then once your state is toggled to **true** the button will change to a blue color and then when it's **false**, it will go back to the original transparent.
Also, make sure your **Category** class is implementing `INotifyPropertyChanged`
