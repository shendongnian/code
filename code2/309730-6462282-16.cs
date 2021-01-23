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
    		private readonly Collection<IFilter> _filters = new Collection<IFilter>();
    		public ICollection<IFilter> Filters { get { return _filters; } }
    
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{
    			return new FilterEventHandler((s, e) =>
    				{
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
    
    	public interface IFilter
    	{
    		bool Filter(object item);
    	}
