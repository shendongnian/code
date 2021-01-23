    using System.Windows;
    using System.Windows.Data;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.GridView;
    using System;
    
    namespace Inspect
    {
    	public class DateTimePickerColumn : GridViewBoundColumnBase
    	{
    		public TimeSpan TimeInterval
    		{
    			get
    			{
    				return (TimeSpan) GetValue(TimeIntervalProperty);
    			}
    			set
    			{
    				SetValue(TimeIntervalProperty, value);
    			}
    		}
    
    		public static readonly DependencyProperty TimeIntervalProperty =
    			DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(DateTimePickerColumn), new PropertyMetadata(TimeSpan.FromHours(1d)));
    
    
    
    		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
    		{
    			this.BindingTarget = RadDateTimePicker.SelectedValueProperty;
    
    			RadDateTimePicker picker = new RadDateTimePicker();
    			picker.IsTooltipEnabled = false;
    
    			picker.TimeInterval = this.TimeInterval;
    
    			picker.SetBinding(this.BindingTarget, this.CreateValueBinding());
    
    			return picker;
    		}
    
    		public override object GetNewValueFromEditor(object editor)
    		{
    			RadDateTimePicker picker = editor as RadDateTimePicker;
    			if (picker != null)
    			{
    				picker.DateTimeText = picker.CurrentDateTimeText;
    			}
    
    			return base.GetNewValueFromEditor(editor);
    		}
    
    		private Binding CreateValueBinding()
    		{
    			Binding valueBinding = new Binding();
    			valueBinding.Mode = BindingMode.TwoWay;
    			valueBinding.NotifyOnValidationError = true;
    			valueBinding.ValidatesOnExceptions = true;
    			valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
    			valueBinding.Path = new PropertyPath(this.DataMemberBinding.Path.Path);
    
    			return valueBinding;
    		}
    	}
    }
