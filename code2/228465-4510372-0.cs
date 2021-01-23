        public string ItemsSource
        {
            get 
            { 
                // Call your OnRead functionality here!
                return (string)GetValue(ItemsSourceProperty); 
            }
            set 
            { 
                SetValue(ItemsSourceProperty, value);
            }
        }
