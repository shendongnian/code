    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Markup;
    using System.Windows.Data;
    using System.Collections.ObjectModel;
    
    namespace Test.MarkupExtensions
    {
    	class FilterExtension : MarkupExtension
    	{
    		public bool AcceptByDefault { get; set; }
    
    		public FilterExtension()
    		{
    			AcceptByDefault = true;
    		}
    		public FilterExtension(bool acceptByDefault)
    		{
    			AcceptByDefault = acceptByDefault;
    		}
    
    		private readonly Collection<FilterBase> _filters = new Collection<FilterBase>();
    		public Collection<FilterBase> Filters { get { return _filters; } }
    
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{
    			return new FilterEventHandler((s, e) =>
    				{
    					e.Accepted = AcceptByDefault;
    					foreach (var filter in Filters)
    					{
    						var res = filter.Filter(e.Item);
    						if (res.HasValue)
    						{
    							e.Accepted = res.Value;
    						}
    					}
    				});
    		}
    	}
    
    	public abstract class FilterBase
    	{
    		public abstract bool? Filter(object item);
    	}
    
    	// Sketchy Example Filter
    	public class PropertyFilter : FilterBase
    	{
    		public string PropertyName { get; set; }
    		public object Value { get; set; }
    
    		public override bool? Filter(object item)
    		{
    			var type = item.GetType();
    			var itemValue = type.GetProperty(PropertyName).GetValue(item, null);
    			if (Value == null && itemValue == null) return true;
    			if (itemValue.Equals(Value))
    			{
    				return true;
    			}
    			else
    			{
    				return null;
    			}
    		}
    	}
    }
