    // fade animation of the Popup to opacity 1.0
        private void ShowPopup()
        {
            exitPopup.Visibility = Visibility.Visible;
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.To = 1;
            fadeAnimation.Duration = TimeSpan.FromSeconds(1);
            //fadeAnimation.FillBehavior = FillBehavior.Stop;
            StoryBoardHelper.SetTarget(fadeAnimation, exitPopup);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(Canvas.Opacity)"));
            storyboard.Children.Add(fadeAnimation);
            storyboard.Duration = fadeAnimation.Duration;
            storyboard.Begin();
        }
        // fade aninmation to opacity 0.0
        private void ClosePopup()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fadeAnimation = new DoubleAnimation();
            fadeAnimation.To = 0;
            fadeAnimation.Duration = TimeSpan.FromSeconds(0.2);
            //fadeAnimation.FillBehavior = FillBehavior.Stop;
            StoryBoardHelper.SetTarget(fadeAnimation, exitPopup);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("(Canvas.Opacity)"));
            storyboard.Children.Add(fadeAnimation);
            storyboard.Duration = fadeAnimation.Duration;
            storyboard.Begin();
            storyboard.Completed += (sender, e) => exitPopup.Visibility = Visibility.Collapsed;
        }
