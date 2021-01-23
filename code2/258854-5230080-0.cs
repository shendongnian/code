    private void MainScatterView_PreviewContactUp(object sender, ContactEventArgs e)
        {
            if (e.GetPosition(this).X < 100 && (coordinates.Height - e.GetPosition(this).Y) < 100)
            {
                string file = e.OriginalSource.ToString();
                UserNotifications.RequestNotification("Notification PreviewContactUp", file, TimeSpan.FromSeconds(2));
            }
        }
