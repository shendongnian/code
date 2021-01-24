    <ListView ItemsSource="{Binding BigList}">
    	<ListView.View>
    		<GridView>
    			<GridViewColumn DisplayMemberBinding="{Binding}"/>
    		</GridView>
    	</ListView.View>
    </ListView>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
    	public IEnumerable<string> BigList { get; }
    
    	public MainWindowViewModel()
    	{
    		var list = new List<string>();
    		for (int i = 0; i < 10000; i++)
    			list.Add(i.ToString());
    		BigList = list;
    	}
    }
