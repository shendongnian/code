    public static T GetVisualDescendant<T>(this DependencyObject visual) where T : DependencyObject
		{
			return (T)visual.GetVisualDescendants().FirstOrDefault(d => d is T);
		}
    public static IEnumerable<DependencyObject> GetVisualDescendants(this DependencyObject visual)
		{
			if (visual == null)
			{
				yield break;
			}
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(visual, i);
				yield return child;
				if (VisualTreeHelper.GetChildrenCount(child) == 0)
				{
					continue;
				}
				foreach (DependencyObject subChild in GetVisualDescendants(child))
				{
					yield return subChild;
				}
			}
		}
 
