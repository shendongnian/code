    public class AddressListBox : ListBox
    {
    	public AddressListBox()
    	{
    		DrawMode = DrawMode.OwnerDrawFixed;
    		ItemHeight = 18;
    	}
    
    	protected override void OnDrawItem(DrawItemEventArgs e)
    	{
    		const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
    
    		if (e.Index >= 0) {
    			e.DrawBackground();
    			e.Graphics.DrawRectangle(Pens.Red, 2, e.Bounds.Y + 2, 14, 14); // Simulate an icon.
    
    			var textRect = e.Bounds;
    			textRect.X += 20;
    			textRect.Width -= 20;
    			string itemText = DesignMode ? "AddressListBox" : Items[e.Index].ToString();
    			TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, e.ForeColor, flags);
    			e.DrawFocusRectangle();
    		}
    	}
    }
