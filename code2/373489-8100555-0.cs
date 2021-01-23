        public static readonly DependencyProperty InteractionsProviderProperty = 
            DependencyProperty.Register("InteractionsProvider", typeof(IInteractionsProvider), typeof(IdattInteractions), new PropertyMetadata(null, OnInteractionsProviderProperty )); 
        private static void OnInteractionsProviderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
             var source = d As MyInteractions;
             if (source ! = null)
             {
                 var oldValue = (IInteractionsProvider)e.OldValue;
                 var newValue = (IInteractionsProvider)e.NewValue;
                 source.OnInteractionsProviderPropertyChanged(oldValue, newValue);
             }
        }
        private void OnInteractionsProviderPropertyChanged(IInteractionsProvider oldValue, IInteractionsProvider newValue)
        {
             if (oldValue != null)
                  oldValue -= InteractionsProvider_InteractionRequested;
             if (newValue != null)
                  newValue += InteractionsProvider_InteractionRequested;
        }
        private void InteractionsProvider_InteractionRequested(object sender, EventArgs e)
        {
            // Do Stuff
        }
