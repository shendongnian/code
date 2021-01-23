    public class myDataGridView : DataGridView
    {
    	protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
    	{
    		base.OnEditingControlShowing(e);
    
    		if (e.Control is ComboBox) {
    			SendKeys.Send("{F4}");
    		}
    	}
    
    }
