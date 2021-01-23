     private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
            {
                ((MediaElement)(sender)).Position = new TimeSpan(0, 0, 0);
                ((MediaElement)(sender)).Play();
            }
