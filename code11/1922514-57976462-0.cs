cs
//Assuming you have access to a viewModel variable and to your MyItemsControl:
//We retrieve the generated container
var container = MyItemsControl.ItemContainerGenerator.ContainerFromItem(viewModel) as FrameworkElement;
//We retrieve the closest ContentPresenter in the visual tree
FrameworkElement firstContentPresenter = FindVisualSelfOrChildren<ContentPresenter>(container);
//We get the first child which is the root of the DataTemplate
FrameworkElement visualRoot = (FrameworkElement)VisualTreeHelper.GetChild(firstContentPresenter, 0); //this is what you want
You need this helper function which parses the visual tree down, looking for the first child of the correct type.
cs
/// <summary>
/// Parses the visual tree down looking for the first descendant (or self if correct type) of the given type.
/// </summary>
/// <typeparam name="T">Type of the descendant to find in the visual tree</typeparam>
/// <param name="child">Visual element to find descendant of</param>
/// <returns>First visual descendant of the given type or null. Can be the passed object itself if type is correct.</returns>
public static T FindVisualSelfOrChildren<T>(DependencyObject parent) where T : DependencyObject {
	if (parent == null) {
		//we've reached the end of the tree
		return null;
	}
	if (parent is T) {
		return parent as T;
	}
	//We get the immediate children
	IEnumerable<DependencyObject> children = Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(parent)).Select(i => VisualTreeHelper.GetChild(parent, i));
	//We parse them to get the first child of correct type
	foreach (var child in children) {
		T result = FindVisualSelfOrChildren<T>(child);
		if (result != null) {
			return result as T;
		}
	}
	//Nothing found
	return null;
}
