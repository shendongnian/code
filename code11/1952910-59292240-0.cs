    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    
    namespace NetworkMonitor.Framework.Controls
    {
    	[ContentProperty(nameof(Items))]
    	public class ToolbarPanel : ItemsControl
    	{
    		static ToolbarPanel()
    		{
    			DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolbarPanel), new FrameworkPropertyMetadata(typeof(ToolbarPanel)));
    		}
    
    		public static readonly DependencyProperty ItemsSpacingProperty = DependencyProperty.Register(
    			nameof(ItemsSpacing), typeof(Thickness), typeof(ToolbarPanel), new PropertyMetadata(default(Thickness)));
    
    		public Thickness ItemsSpacing
    		{
    			get { return (Thickness) GetValue(ItemsSpacingProperty); }
    			set { SetValue(ItemsSpacingProperty, value); }
    		}
    	}
    }
