lang-xml
<TextBox Text="{Binding Source={StaticResource UserViewModel}, Path=Username}"/>
The ViewModel might look like:
lang-cs
public class UserViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;
    public string Username {
        get { return _username; }
        set {
            _username = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Username"));
        }
    }
    private string _username;
    public UserViewModel() { }
}
Whenever the Username property is changed on the UserViewModel class, the text box will update to display the new value.
However, this approach doesn't work for all situations. When working with boolean values, it's often useful to implement data triggers:
lang-xml
<TextBox Text="{Binding Source={StaticResource UserViewModel}, Path=Username}">
    <TextBlock.Style>
        <Style TargetType="{x:Type TextBox}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Source={StaticResource UserViewModel}, Path=IsTaken}" Value="True">
                            <Setter Property="Background" Value="Red"></Setter>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
</TextBox>
This code extends the previous example to color the background of the text box red if the IsTaken property is set to true on the ViewModel. A nice thing about data triggers is that they reset themselves; for example, if the value is set to false the background will revert to its original color.
If you want to go the other way, and notify the ViewModel of user input or a similarly important event, you can use commands. Commands can be bound to properties in XAML, and are implemented by the ViewModel. They are called when the user performs a certain action, such a clicking a button. Commands can be created by implementing the ICommand interface.
