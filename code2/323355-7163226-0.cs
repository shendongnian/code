		public class ElementProxy : DependencyObject
		{
			public DependencyObject Element
			{
				get { return (DependencyObject)GetValue(ElementProperty); }
				set { SetValue(ElementProperty, value); }
			}
		public static readonly DependencyProperty ElementProperty =
			DependencyProperty.Register("Element", typeof(DependencyObject), typeof(ElementProxy), new PropertyMetadata(null));
		}
