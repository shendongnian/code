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
