    using System.Windows;
	using System.Windows.Input;
	using System.Windows.Media;
    // By adding this attached property to any control on the window, 
    // the entire window will be dragged if you click and move the mouse:
    // It searches up the visual tree until it finds the parent Window,
    // then calls .DragMove() on it.
	namespace DXApplication1.AttachedProperty
	{
		public class EnableDragHelper
		{
			public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
				"EnableDrag",
				typeof (bool),
				typeof (EnableDragHelper),
				new PropertyMetadata(default(bool), OnLoaded));
			private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
			{
				var uiElement = dependencyObject as UIElement;
				if (uiElement != null)
				{
					uiElement.MouseMove += UIElementOnMouseMove;
				}
			}
			private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
			{
				var layoutPanel = sender as UIElement;
				if (layoutPanel != null)
				{
					if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
					{
						DependencyObject parent = VisualTreeHelper.GetParent(layoutPanel);
						int avoidInfiniteLoop = 0;
						while ((parent is Window) == false)
						{
							parent = VisualTreeHelper.GetParent(parent);
							avoidInfiniteLoop++;
							if (avoidInfiniteLoop == 1000)
							{
								// Something is wrong - we could not find the parent window.
								return;
							}
						}
						var window = parent as Window;
						window.DragMove();
					}
				}
			}
			public static void SetEnableDrag(DependencyObject element, bool value)
			{
				element.SetValue(EnableDragProperty, value);
			}
			public static bool GetEnableDrag(DependencyObject element)
			{
				return (bool)element.GetValue(EnableDragProperty);
			}
		}
	}
