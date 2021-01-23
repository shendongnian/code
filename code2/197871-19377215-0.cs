    public class TextBlockAutoShrink : TextBlock
        {
           // private Viewbox _viewBox;
            private double _defaultMargin = 6;
            private Typeface _typeface;
    
            static TextBlockAutoShrink()
            {
                TextBlock.TextProperty.OverrideMetadata(typeof(TextBlockAutoShrink), new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));
            }
    
            public TextBlockAutoShrink() : base() 
            {
                _typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch, this.FontFamily);
                base.DataContextChanged += new DependencyPropertyChangedEventHandler(TextBlockAutoShrink_DataContextChanged);
            }
    
            private static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
            {
                var t = sender as TextBlockAutoShrink;
                if (t != null)
                {
                    t.FitSize();
                }
            }
    
            void TextBlockAutoShrink_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                FitSize();
            }
    
            protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
            {
                FitSize();
    
                base.OnRenderSizeChanged(sizeInfo);
            }
            
    
            private void FitSize()
            {
                FrameworkElement parent = this.Parent as FrameworkElement;
                if (parent != null)
                {
                    var targetWidthSize = this.FontSize;
                    var targetHeightSize = this.FontSize;
    
                    var maxWidth = double.IsInfinity(this.MaxWidth) ? parent.ActualWidth : this.MaxWidth;
                    var maxHeight = double.IsInfinity(this.MaxHeight) ? parent.ActualHeight : this.MaxHeight;
    
                    if (this.ActualWidth > maxWidth)
                    {
                        targetWidthSize = (double)(this.FontSize * (maxWidth / (this.ActualWidth + _defaultMargin)));
                    }
    
                    if (this.ActualHeight > maxHeight)
                    {
                        var ratio = maxHeight / (this.ActualHeight);
    
                        // Normalize due to Height miscalculation. We do it step by step repeatedly until the requested height is reached. Once the fontsize is changed, this event is re-raised
                        // And the ActualHeight is lowered a bit more until it doesnt enter the enclosing If block.
                        ratio = (1 - ratio > 0.04) ? Math.Sqrt(ratio) : ratio;
    
                        targetHeightSize = (double)(this.FontSize *  ratio);
                    }
    
                    this.FontSize = Math.Min(targetWidthSize, targetHeightSize);
                }
            }
        }
