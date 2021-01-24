    private bool toRight=true;
    private void Timer_Tick(object sender, object e)
    {
        if(toRight)
        {
            if (Canvas.GetLeft(_wolves.WolvesLeftAvatar()) <= 1920)
            {
                double x = Canvas.GetLeft(_wolves.WolvesLeftAvatar());
                _wolves.WolvesLeftAvatar().Visibility = Visibility.Collapsed;
                _wolves.WolvesRightAvatar().Visibility = Visibility.Visible;
                x += 5;
                Canvas.SetLeft(_wolves.WolvesRightAvatar(),x);  
                Canvas.SetLeft(_wolves.WolvesLeftAvatar(),x);
            }
            else
            {
                toRight=false;
                double x = Canvas.GetLeft(_wolves.WolvesLeftAvatar());
                _wolves.WolvesLeftAvatar().Visibility = Visibility.Visible;
                _wolves.WolvesRightAvatar().Visibility = Visibility.Collapsed;
                x -= 5;
                Canvas.SetLeft(_wolves.WolvesRightAvatar(), x);
                Canvas.SetLeft(_wolves.WolvesLeftAvatar(), x);
            }
        }
        else
        {
            if (Canvas.GetLeft(_wolves.WolvesLeftAvatar()) >= 0)
            {
                double x = Canvas.GetLeft(_wolves.WolvesLeftAvatar());
                _wolves.WolvesLeftAvatar().Visibility = Visibility.Visible;
                _wolves.WolvesRightAvatar().Visibility = Visibility.Collapsed;
                x -= 5;
                Canvas.SetLeft(_wolves.WolvesRightAvatar(), x);
                Canvas.SetLeft(_wolves.WolvesLeftAvatar(), x);
            }
            else
            {
                toRight=true;
                double x = Canvas.GetLeft(_wolves.WolvesLeftAvatar());
                _wolves.WolvesLeftAvatar().Visibility = Visibility.Collapsed;
                _wolves.WolvesRightAvatar().Visibility = Visibility.Visible;
                x += 5;
                Canvas.SetLeft(_wolves.WolvesRightAvatar(),x);    
                Canvas.SetLeft(_wolves.WolvesLeftAvatar(),x);
            }
        }
    }
