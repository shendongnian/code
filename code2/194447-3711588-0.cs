    public class TextOnAPath : Panel
    {
    	public TextOnAPath() {
    		var textBlock = new TextBlock();
    		textBlock.Text = "Test";
    		textBlock.Background = Brushes.Blue;
    		textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Top;
    		textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
    		this.Children.Add(textBlock);
    
    		this.Background = Brushes.Gray;
    	}
    
    	protected override Size MeasureOverride(Size availableSize) {
    		return availableSize;
    	}
    
    	protected override Size ArrangeOverride(Size finalSize) {
    		foreach (UIElement child in this.Children)
    			child.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
    		return finalSize;
    	}
    }
