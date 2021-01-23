     private void gifAnimation_MediaEnded(object sender, RoutedEventArgs e)
     {
        gifAnimation.Position = new TimeSpan(0,0,1);
        gifAnimation.Play();
     }
