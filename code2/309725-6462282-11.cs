    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Markup;
    using System.Windows.Data;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Text.RegularExpressions;
    
    namespace Test.MarkupExtensions
    {
    	[ContentProperty("Filters")]
    	class FilterExtension : MarkupExtension
    	{
    		public enum AcceptMode { Accept, Reject }
    		public AcceptMode Default { get; set; }
    
    		public FilterExtension()
    		{
    			Default = AcceptMode.Accept;
    		}
    
    		private readonly Collection<FilterBase> _filters = new Collection<FilterBase>();
    		public Collection<FilterBase> Filters { get { return _filters; } }
    
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{
    			return new FilterEventHandler((s, e) =>
    				{
    					e.Accepted = Default == AcceptMode.Accept;
    					foreach (var filter in Filters)
    					{
    						var res = filter.Filter(e.Item);
    						if (!res)
    						{
    							e.Accepted = false;
    							return;
    						}
    					}
    					e.Accepted = true;
    				});
    		}
    	}
    
    	public abstract class FilterBase : DependencyObject
    	{
    		public abstract bool Filter(object item);
    	}
    
    	// Sketchy Example Filter
    	public class PropertyFilter : FilterBase
    	{
    		public static readonly DependencyProperty PropertyNameProperty =
    			DependencyProperty.Register("PropertyName", typeof(string), typeof(PropertyFilter), new UIPropertyMetadata(null));
    		public string PropertyName
    		{
    			get { return (string)GetValue(PropertyNameProperty); }
    			set { SetValue(PropertyNameProperty, value); }
    		}
    		public static readonly DependencyProperty ValueProperty =
    			DependencyProperty.Register("Value", typeof(object), typeof(PropertyFilter), new UIPropertyMetadata(null));
    		public object Value
    		{
    			get { return (object)GetValue(ValueProperty); }
    			set { SetValue(ValueProperty, value); }
    		}
    		public static readonly DependencyProperty RegexPatternProperty =
    			DependencyProperty.Register("RegexPattern", typeof(string), typeof(PropertyFilter), new UIPropertyMetadata(null));
    		public string RegexPattern
    		{
    			get { return (string)GetValue(RegexPatternProperty); }
    			set { SetValue(RegexPatternProperty, value); }
    		}
    
    		public override bool Filter(object item)
    		{
    			var type = item.GetType();
    			var itemValue = type.GetProperty(PropertyName).GetValue(item, null);
    			if (RegexPattern == null)
    			{
    				return (object.Equals(itemValue, Value));
    			}
    			else
    			{
    				if (itemValue is string == false)
    				{
    					throw new Exception("Cannot match non-string with regex.");
    				}
    				else
    				{
    					return Regex.Match((string)itemValue, RegexPattern).Success;
    				}
    			}
    		}
    	}
    }
