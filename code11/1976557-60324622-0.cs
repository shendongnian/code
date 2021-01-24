		private static System.Timers.Timer aTimer;
		private static void SetTimer()
		{
			// Create a timer with a two second interval.
			aTimer = new System.Timers.Timer(2000);
			// Hook up the Elapsed event for the timer. 
			aTimer.Elapsed += OnTimedEvent;
			aTimer.AutoReset = true;
			aTimer.Enabled = true;
		}
		private static void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 userdaten.image FROM userdaten ORDER BY Rnd(ID)", con);
			con.Open();
			OleDbDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read()) { PictureTrainLabel.Text = "~/Image/" + dr["image"].ToString(); }
				PictureTrain.ImageUrl = PictureTrainLabel.Text;
			}
			con.Close();
		}
