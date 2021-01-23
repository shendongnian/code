    public class TransmissionListBox : ListBox
    {
    	public TransmissionListBox()
    	{
    		this.DrawMode = DrawMode.OwnerDrawFixed;
    	}
    
    	protected override void OnDrawItem(DrawItemEventArgs e)
    	{
    		e.DrawBackground();
    		for (int i = 0; i < Items.Count; i++) {
    			var displayItem = Items[i] as IDisplayItem;
    			// TextRenderer.DrawText(e.Graphics,displayItem.Subject,e.Font,...);
    			// e.Graphics.DrawIcon(...);
    			// and so on
    		}
    		e.DrawFocusRectangle();
    
    	}
    }
