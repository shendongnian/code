    public class TransmissionListBox : ListBox
    {
    	public TransmissionListBox()
    	{
    		this.DrawMode = DrawMode.OwnerDrawFixed;
    	}
    
    	protected override void OnDrawItem(DrawItemEventArgs e)
    	{
    		e.DrawBackground();
    		if (e.Index >= 0 && e.Index < Items.Count) {
    			var displayItem = Items[e.Index] as IDisplayItem;
    			TextRenderer.DrawText(e.Graphics,displayItem.Subject,e.Font,...);
    			e.Graphics.DrawIcon(...);
    			// and so on
    		}
    		e.DrawFocusRectangle();
    	}
    }
