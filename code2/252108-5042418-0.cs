    public class MyDGV : DataGridView
    {
    	public MyDGV()
    	{
    		DataSourceChanged += (s, e) => SaveLayoutToFile();
    		DataBindingComplete += (s, e) => RestoreLayoutFromFile();
    	}
    }
