	using ReactiveUI;
	using ReactiveUI.Utils;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reactive.Linq;
	using System.Windows;
	using System.Windows.Documents;
	
	namespace My.Controls
	{
	    public class EnumComboBox : System.Windows.Controls.ComboBox
	    {
	        static EnumComboBox()
	        {
	            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumComboBox), new FrameworkPropertyMetadata(typeof(EnumComboBox)));
	        }
	
	        protected override void OnInitialized( EventArgs e )
	        {
	            base.OnInitialized(e);
	
	            this.WhenAnyValue(p => p.SelectedValue)
	                .Where(p => p != null)
	                .Select(o => o.GetType())
	                .Where(t => t.IsEnum)
	                .DistinctUntilChanged()
	                .ObserveOn(RxApp.MainThreadScheduler)
	                .Subscribe(FillItems);
	        }
	
	        private void FillItems(Type enumType)
	        {
	            List<KeyValuePair<object, string>> values = new List<KeyValuePair<object,string>>();
	
	            foreach (var idx in EnumUtils.EnumToList(enumType))
	            {
	                values.Add(new KeyValuePair<object, string>(idx.Item1, idx.Item2));
	            }
	
	            this.ItemsSource = values.Select(o=>o.Key.ToString()).ToList();
	
	            UpdateLayout();
	            this.ItemsSource = values;
	            this.DisplayMemberPath = "Value";
	            this.SelectedValuePath = "Key";
	                 
	        }
	    }
	}
	
