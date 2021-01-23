        Splash s = new Splash();
                    DoubleAnimation fade = new DoubleAnimation()
                    {
                        Duration = new Duration(TimeSpan.FromMilliseconds(4000)),
                        From = 1.0,
                        To = 0.0,
                        RepeatBehavior = new RepeatBehavior(1)
                       
                    };
        
                    fade.Completed += new EventHandler(fade_Completed);
        
                    this.popup = new Popup();
                    this.popup.Child = s;
        
                    Storyboard.SetTargetProperty(fade, new PropertyPath(UIElement.OpacityProperty));
                    sb.Children.Add(fade);
                    Storyboard.SetTarget(sb, s);           
                    
                    this.popup.IsOpen = true;
        
                    sb.Begin();
