    using System.Reflection;
    using Microsoft.Windows.Controls;
    
    namespace Bartosz.Wojtowicz.Wpf
    {
    	public class PastableDataGridTemplateColumn : DataGridTemplateColumn
    	{
    		public string BindingPath { get; set; }
    
    		public override void OnPastingCellClipboardContent(object item, object cellContent)
    		{
    			if (item != null)
    			{
    				PropertyInfo propertyInfo = item.GetType().GetProperty(BindingPath);
    				if (propertyInfo != null)
    				{
    					propertyInfo.SetValue(item, cellContent, null);
    				}
    			}
    			base.OnPastingCellClipboardContent(item, cellContent);
    		}
    	}
    }
 
