        public bool Test
        {
            get
            {
                return (bool)GetValue(TestProperty);
            }
            set
            {
                SetValue(TestProperty, value);
            }
        }
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(bool), typeof(CustomGrid),
                new PropertyMetadata(new PropertyChangedCallback
                    ((obj, propChanged) =>
                    {
                        CustomGrid control = obj as CustomGrid;
                        if (control != null)
                        {
                            Storyboard sb = new Storyboard() { Duration = new Duration(TimeSpan.FromMilliseconds(500)) };
                            Random rand = new Random();
                            Color col = new Color()
                            {
                                A = 100,
                                R = (byte)(rand.Next() % 255),
                                G = (byte)(rand.Next() % 255),
                                B = (byte)(rand.Next() % 255)
                            };
                            ColorAnimation colAnim = new ColorAnimation();
                            colAnim.To = col;
                            colAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                            sb.Children.Add(colAnim);
                            Storyboard.SetTarget(colAnim, control);
                            Storyboard.SetTargetProperty(colAnim, new PropertyPath("(Panel.Background).(SolidColorBrush.Color)"));
                            sb.Begin();
                        }
                    }
                )));
    }
