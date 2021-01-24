    private void btnContinue_Click(object sender, RoutedEventArgs e)
    {
        if (score >= 2)
        {
            GameOver.Visibility = Visibility.Hidden;
            btnRestart.Visibility = Visibility.Hidden;
            score -= 2;
            
            // Pause movement
            paused = true;
            moveTimer.Start();
            UpdateField();
        }
        else
        {
            tBNotEnoughPoints.Visibility = Visibility.Visible;
        }
    }
