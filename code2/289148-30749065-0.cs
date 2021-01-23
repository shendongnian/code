        // animazione periferica
        public static void LineAnimation(Line _line,String _colore)
        {
            Storyboard result = new Storyboard();
            Duration duration = new Duration(TimeSpan.FromSeconds(2));
            ColorAnimation animation = new ColorAnimation();
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = duration;
            switch (_colore.ToUpper())
            {
                case "RED": 
                    animation.From = Colors.Red;
                    break;
                case "ORANGE": 
                    animation.From = Colors.Orange;
                    break;
                case "YELLOW": 
                    animation.From = Colors.Yellow;
                    break;
                case "GRAY": 
                    animation.From = Colors.DarkGray;
                    break;
                default: 
                    animation.From = Colors.Green;
                    break;
            }
            animation.To = Colors.Gray;
            Storyboard.SetTarget(animation, _line);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Line.Stroke).(SolidColorBrush.Color)"));
            result.Children.Add(animation);
            result.Begin();
        }
    }
