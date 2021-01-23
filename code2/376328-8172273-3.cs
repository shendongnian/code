    public class MyViewModel : ViewModelBase //Implements INotifyPropertyChanged
    {
        public MyViewModel()
        {
            DoSomethingCommand = new RelayCommand(DoSomething, CanDoSomething);
        }
    
        public ObservableCollection<Object> MyItems { get; set; }
        public Object SelectedItem { get; set; }
    
        public RelayCommand DoSomethingCommand { get; set; }
    
    
        public void DoSomething() { }
    
        public Boolean CanDoSomething() { return (SelectedItem != null); }
    }
    <ListView ItemsSource="{Binding MyItems}" SelectedItem="{Binding SelectedItem}" ... />
    <Button Command="{Binding DoSomethingCommand}" ... />
