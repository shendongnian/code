    private bool toRight=true;
    private void MoveX(int m)
    {
        double x = Canvas.GetLeft(_wolves.WolvesLeftAvatar());
        if(m>0)
        {
            _wolves.WolvesLeftAvatar().Visibility = Visibility.Collapsed;
            _wolves.WolvesRightAvatar().Visibility = Visibility.Visible;
        }
        else
        {
            _wolves.WolvesLeftAvatar().Visibility = Visibility.Visible;
            _wolves.WolvesRightAvatar().Visibility = Visibility.Collapsed;
        }
        x += m;
        Canvas.SetLeft(_wolves.WolvesRightAvatar(),x);    
        Canvas.SetLeft(_wolves.WolvesLeftAvatar(),x);
    }
    private void Timer_Tick(object sender, object e)
    {
        if(toRight)
        {
            if (Canvas.GetLeft(_wolves.WolvesLeftAvatar()) <= 1920)
            {
                MoveX(5);
            }
            else
            {
                toRight=false;
                MoveX(-5);
            }
        }
        else
        {
            if (Canvas.GetLeft(_wolves.WolvesLeftAvatar()) >= 0)
            {
                MoveX(-5);
            }
            else
            {
                toRight=true;
                MoveX(5);
            }
        }
    }
