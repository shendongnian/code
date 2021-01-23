            #region MyCustomText
    
    		public string MyCustomText
    		{
    			get { return GetValue(MyCustomTextProperty) as string; }
    			set { SetValue(MyCustomTextProperty, value); }
    		}
    
    		public static readonly DependencyProperty MyCustomTextProperty = DependencyProperty.Register("MyCustomText",
    		  typeof(string), typeof(MyUserControl), new System.Windows.PropertyMetadata(null, new PropertyChangedCallback(OnMyCustomTextChanged)));
    
    		public static void OnMyCustomTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    		{
    			var control = sender as MyUserControl;
    			var value = e.NewValue as string;
    		}
    
    		#endregion MyCustomText
