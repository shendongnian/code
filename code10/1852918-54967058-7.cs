        bool IsAnimationstarted = true;
    private void ImageControl_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (IsAnimationstarted)
        {
            MyStoryboard.Stop();
            IsAnimationstarted = false;
        }
        else
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(6000);
            Prope11.Duration = ts;
            MyStoryboard.Begin();
            IsAnimationstarted = true;
        }
    }
    }
