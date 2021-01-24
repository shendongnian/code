    using System.Windows;
    using System.Windows.Controls;
    
    namespace NetworkMonitor.Framework.Controls.Extensions
    {
    	public class PanelExtensions
    	{
    		public static readonly DependencyProperty ChildMarginProperty = DependencyProperty.RegisterAttached(
    			"ChildMargin", typeof(Thickness), typeof(PanelExtensions), new UIPropertyMetadata(new Thickness(), ChildMarginChanged));
    
    		private static void ChildMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			if (d is Panel panel)
    			{
    				panel.Loaded += PanelOnLoaded;
    			}
    		}
    
    		private static void PanelOnLoaded(object sender, RoutedEventArgs e)
    		{
    			if (sender is Panel panel)
    			{
    				panel.Loaded -= PanelOnLoaded;
    
    				var itemsMargin = GetChildMargin(panel);
    				var skipLast = GetSkipLastMargin(panel);
    
    				for (int i = 0; i < panel.Children.Count; i++)
    				{
    					if (skipLast && i == (panel.Children.Count - 1))
    						break;
    
    					var child = panel.Children[i];
    					if (child is FrameworkElement frameworkElement)
    					{
    						frameworkElement.Margin = itemsMargin;
    					}
    				}
    			}
    		}
    
    		[AttachedPropertyBrowsableForChildren(IncludeDescendants = true)]
    		[AttachedPropertyBrowsableForType(typeof(Panel))]
    		public static void SetChildMargin(DependencyObject element, Thickness value)
    		{
    			element.SetValue(ChildMarginProperty, value);
    		}
    
    		[AttachedPropertyBrowsableForChildren(IncludeDescendants = true)]
    		[AttachedPropertyBrowsableForType(typeof(Panel))]
    		public static Thickness GetChildMargin(DependencyObject element)
    		{
    			return (Thickness) element.GetValue(ChildMarginProperty);
    		}
    
    		public static readonly DependencyProperty SkipLastMarginProperty = DependencyProperty.RegisterAttached(
    			"SkipLastMargin", typeof(bool), typeof(PanelExtensions), new PropertyMetadata(true));
    
    		public static void SetSkipLastMargin(DependencyObject element, bool value)
    		{
    			element.SetValue(SkipLastMarginProperty, value);
    		}
    
    		public static bool GetSkipLastMargin(DependencyObject element)
    		{
    			return (bool) element.GetValue(SkipLastMarginProperty);
    		}
    	}
    }
