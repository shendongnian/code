	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
            //retrieve position from userstate
            Position pos = e.UserState as Position;
            some_counter_or_progressbar.Value = e.ProgressPercentage;
            textboxLatitude.Text = pos.Lat.ToString();
            textboxLongitude.Text = pos.Long.ToString();
	}
