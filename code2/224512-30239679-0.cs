    public class MenuItemIconHelper
	{
		#region ImageSource Icon
		public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(MenuItemIconHelper), new PropertyMetadata(default(ImageSource), IconPropertyChangedCallback));
		private static void IconPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			var i = (MenuItem)obj;
			if (e.NewValue != null)
				i.Icon = new Image() {Source = (ImageSource)e.NewValue};
			else
				i.Icon = null;
		}
		public static void SetIcon(DependencyObject element, ImageSource value)
		{
			element.SetValue(IconProperty, value);
		}
		public static ImageSource GetIcon(DependencyObject element)
		{
			return (ImageSource)element.GetValue(IconProperty);
		}
		#endregion
	}
