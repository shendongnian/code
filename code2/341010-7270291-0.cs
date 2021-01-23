        public Order CurrentOrder
        {
            get { return (Order)GetValue(CurrentOrderProperty); }
            set { SetValue(CurrentOrderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentOrder.  This enables binding, etc.
        public static readonly DependencyProperty CurrentOrderProperty =
            DependencyProperty.Register("CurrentOrder", typeof(Order), typeof(MyUserControl), new PropertyMetadata(null, OnCurrentOrderPropertyChanged));
        public static void OnCurrentOrderPropertyChanged(DependencyObject Sender, DependencyPropertyChangedEventArgs e)
        {
            var sender = Sender as MyUserControl;
            var NewValue = e.NewValue as Order;
            var OldValue = e.OldValue as Order;
            if (OldValue != null && sender != null)
	        {
		        //Use old value as needed and use sender instead of this as method is static.
	        }
            if (NewValue != null && sender != null)
            {
                //Use new value as needed and use sender instead of this as method is static.
            }
        }
