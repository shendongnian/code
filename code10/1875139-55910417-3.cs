     public Brush fillcolor
            {
                get { return (Brush)GetValue(fillcolorProperty); }
                set { SetValue(fillcolorProperty, value); }
            }
     public static readonly DependencyProperty fillcolorProperty =
                DependencyProperty.Register("fillcolor", typeof(Brush), typeof(MyUserControl), null);
