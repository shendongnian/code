     public void WipeAnimation(FrameworkElement ObjectToAnimate)
            {
                LinearGradientBrush OpacityBrush = new LinearGradientBrush();
                OpacityBrush.StartPoint = new Point(1, 0);
                OpacityBrush.EndPoint = new Point(0, 0);
                GradientStop BlackStop = new GradientStop(Colors.Black, 0);
                 GradientStop TransparentStop = new GradientStop(Colors.Transparent, 0);
                OpacityBrush.GradientStops.Add(BlackStop);
                OpacityBrush.GradientStops.Add(TransparentStop);
                ObjectToAnimate.OpacityMask = OpacityBrush;
    
                this.RegisterName("TransparentStop", TransparentStop);
                this.RegisterName("BlackStop", BlackStop);
    
                Duration d = TimeSpan.FromSeconds(4);
                Storyboard sb = new Storyboard() { Duration = d };
                DoubleAnimation DA = new DoubleAnimation() { By = 1, Duration = d };
                DoubleAnimation DA2 = new DoubleAnimation() { By = 1, Duration = d };
                sb.Children.Add(DA); sb.Children.Add(DA2);
                Storyboard.SetTargetName(DA, "TransparentStop");
                Storyboard.SetTargetName(DA2, "BlackStop");
                Storyboard.SetTargetProperty(DA, new PropertyPath("Offset"));
                Storyboard.SetTargetProperty(DA2, new PropertyPath("Offset"));
                sb.Begin(this);
            }
