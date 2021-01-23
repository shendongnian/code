	private bool InFrontOf(FrameworkElement c1, FrameworkElement c2){
		Panel root = FindWindowRoot(c1); // Find the root of the document, assumes that c1 and c2 are part of the same document
		Trace.Assert(root != null, "root of ui element is not a window or a panel that contains children");
		int z1 = Math.Max(Panel.GetZIndex(c1), GetDrawOrder(root, c1));
		int z2 = Math.Max(Panel.GetZIndex(c2), GetDrawOrder(root, c2));
		return z1 > z2;
	}
	private Panel FindWindowRoot(FrameworkElement child)
	{
		FrameworkElement current = child;
		while(current as Window == null)
		{
			current = (FrameworkElement)VisualTreeHelper.GetParent(current); 
		}
		return ((Window)current).Content as Panel;
	}
	private int GetDrawOrder(Panel root, FrameworkElement needle)
	{
		int result = 0;
		FrameworkElement current = root;
		Queue<FrameworkElement> toSearch = new Queue<FrameworkElement>();
		toSearch.Enqueue(current);
		while(needle != current)
		{
			if(current is Panel)
			{
				Panel p = (Panel) current;
				foreach (FrameworkElement frameworkElement in p.Children)
				{
					toSearch.Enqueue(frameworkElement);
				}
			}
			if (current is ContentControl)
			{
				ContentControl cc = (ContentControl)current;
				if(cc.Content as FrameworkElement != null)
					toSearch.Enqueue(cc.Content as FrameworkElement);
			}
			current = toSearch.Dequeue();
			result++;
		}
		return result;
	}
