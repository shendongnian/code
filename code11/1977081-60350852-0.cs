    namespace AlphaChannelAnimation
        {
        class AnimationProperties 
        {
    
    
            public static byte GetBackgroundAlpha(DependencyObject obj)
            {
                return (byte)obj.GetValue(BackgroundAlphaProperty);
            }
    
            public static void SetBackgroundAlpha(DependencyObject obj, byte value)
            {
                obj.SetValue(BackgroundAlphaProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for BackgroundAlpha.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty BackgroundAlphaProperty =
                DependencyProperty.RegisterAttached("BackgroundAlpha", typeof(byte), typeof(AnimationProperties), new PropertyMetadata((byte)255, OnBackgroundAlphaChanged));
    
            private static void OnBackgroundAlphaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                try
                {
                    Color C = ((SolidColorBrush)((Border)d).Background).Color;
                    ((Border)d).Background = new SolidColorBrush { Color = new Color() { R = C.R, G = C.G, B = C.B, A = (byte)e.NewValue } };
                } catch (Exception)
                {
                    throw;
                }
            }
        }
    }
