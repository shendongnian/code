    bool IsAnimationstarted = true;
    private void ImageControl_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Storyboard board = (Storyboard)this.FindResource("Animation1");
        if (IsAnimationstarted)
        {
            IsAnimationstarted = false;
            board.Begin();
        }
        else
        {
            IsAnimationstarted = true;
            board.Pause();
        }
    }
