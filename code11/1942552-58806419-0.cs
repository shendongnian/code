    <TabControl x:Name="TabControl1"
                        Margin="10"
                        ItemsSource="{Binding Employees}"
                        SelectedItem="{Binding SelectedEmployee}">
    </TabControl>
    public class ViewModel
    {
    	private Employee _selectedEmployee;
     	
    	public IList<Employee> Employees { get; private set; }
    
    	public Employee SelectedEmployee
    	{
            get { return _selectedEmployee; }
            set
            {
            	if (_selectedEmployee == value)
            	{
            		return;
            	}
    
                _selectedEmployee = value;
                OnNotifyPropertyChanged();
            }
    	}
    }
