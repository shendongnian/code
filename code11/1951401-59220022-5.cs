     private static void OnScaleFactorsChange(BindableObject bindable, object oldvalue, object newValue)
            {
                (bindable as CustomView).ChangeScale();
            }
    
            private void ChangeScale()
            {
                var itemWd = this.Width;
    
                var itemPresent = this.ScrollViewWidth / this.Width;
                double ratio = 0;
    
                var scrolledItems = this.ScrolledPosition / this.Width;
                
                double totalRatio = ((this.Position - 0.5 - scrolledItems) / (itemPresent / 2));
    
                if (totalRatio > 0 && totalRatio < 2)
                {
                    ratio = totalRatio > 1 ? 2 - totalRatio : totalRatio;
                }
    
                // Minimum scale 0.75 , maximum scale 1(0.75 + 0.25)
                this.Scale = 0.75 + 0.25 * ratio;
            }
    
    Also call the scale changing method in SizeChanged event
    
            public CustomView()
            {
                InitializeComponent();
                this.SizeChanged += CustomView_SizeChanged;
            }
    
            private void CustomScrollView_SizeChanged(object sender, EventArgs e)
            {
                ChangeScale();
            }
