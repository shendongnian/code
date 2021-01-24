xaml
<ListView>
    <i:Interaction.Triggers>
        <i:EventTrigger EventName="MouseDoubleClick">
            <i:InvokeCommandAction Command="{Binding YourCommand}"
                                   CommandParameter="{Binding SelectedItem, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}}"/>
        </i:EventTrigger>
    </i:Interaction.Triggers>
</ListView>
**In your View Model:**
csharp
public ICommand YourCommand { get;set; }
// Initialize your command inside the constructor
YourCommand = new RelayCommand<TType>(YourCommandExecute); // that TType is the type of your elements in the listview
private void YourCommandExecute(TType selectedElement)
{
    // Your logic is implemented here
}
**Relay Command Implementation**
 csharp
// Simple Implementation of Generic Relay Command:
public class RelayCommand<T> : ICommand
{
    private Action<T> execute;
    private Func<T,bool> canExecute;
    public event EventHandler CanExecuteChanged;
    public RelayCommand(Action<T> execute,Func<T,bool> canExecute=null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }
    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute((T)parameter);
    }
    public void Execute(object parameter)
    {
        execute((T)parameter);
    }
}
