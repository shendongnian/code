	/// <summary>
	/// Finds first child of provided type. If child not found, null is returned
	/// </summary>
	/// <typeparam name="T">Type of chiled to be found</typeparam>
	/// <param name="source"></param>
	/// <returns></returns>
	public static T FindChildOfType<T>(this DependencyObject originalSource) where T : DependencyObject
	{
		T ret = originalSource as T;
		DependencyObject child = null;
		if (originalSource != null && ret == null)
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(originalSource); i++)
			{
				child = VisualTreeHelper.GetChild(originalSource, i);
				if (child != null)
				{
					if (child is T)
					{
						ret = child as T;
						break;
					}
					else
					{
						ret = child.FindChildOfType<T>();
						if (ret != null)
						{
							break;
						}
					}
				}
			}
		}
		return ret;
	}
