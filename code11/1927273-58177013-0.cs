private RelayCommand IsSelectedCommand {get; set;}
// then your void isSelected function, this is the command to be called if button is clicked
public void isSelectedCommand()
{
    IsSelected = !IsSelected;
}
public your_model()
{
    this.IsSelectedCommand = new RelayCommand(this.isSelectedCommand)
}
Then bind this `RelayCommand`'s `IsSelectedCommand` instead of binding directly your `IsSelected` in your `Button` in your **View**.
<Button Command="{Binding IsSelectedCommand, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"> Click </Button>
