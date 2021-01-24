    public Validate ()
    		{
    			InitializeComponent ();
    
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (picker.ItemsSource != null)
                    {
                        picker.Focus();
    
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
