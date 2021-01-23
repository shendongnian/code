    public static void UpdateAllBindingSources(this DependencyObject obj)
	{
		foreach (var binding in obj.GetAllBindings())
			binding.UpdateSource();
	}
	public static IEnumerable<BindingExpression> GetAllBindings(this DependencyObject obj)
	{
		var stack = new Stack<DependencyObject>();
		stack.Push(obj);
		while (stack.Count > 0)
		{
			var cur = stack.Pop();
			var lve = cur.GetLocalValueEnumerator();
			while (lve.MoveNext())
				if (BindingOperations.IsDataBound(cur, lve.Current.Property))
					yield return lve.Current.Value as BindingExpression;
			int count = VisualTreeHelper.GetChildrenCount(cur);
			for (int i = 0; i < count; ++i)
			{
				var child = VisualTreeHelper.GetChild(cur, i);
				if (child is FrameworkElement)
					stack.Push(child);
			}
		}
	}
