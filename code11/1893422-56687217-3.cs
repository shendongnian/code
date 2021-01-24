xaml
<TextBox Text ="{Binding Text, UpdateSourceTrigger=PropertyChanged}"/>
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
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
public class SampleViewModel : INotifyPropertyChanged {
    private string _Text;
    public event PropertyChangedEventHandler PropertyChanged;
    public string Text {
        get { return _Text; }
        set {
            if (_Text != value) {
                _Text = value;
                RaisePropertyChanged();
            }
        }
    }
    public ICommand YourCommand { get; set; }
    public SampleViewModel() {
        YourCommand = new RelayCommand<TType>(YourCommandExecute); // that TType is the type of your elements in the listview
    }
    
    // Here I will assume that your TType has a property named Description
    private void YourCommandExecute(TType selectedElement) {
        Text = selectedItem.Description;
    }
    
    public void RaisePropertyChanged([CallerMemberName] propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
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
