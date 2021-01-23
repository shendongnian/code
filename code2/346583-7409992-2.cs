        private void btn_WeightBalance_Populate_Click(object sender, EventArgs e)
        {
            int passengers = Convert.ToInt32(txt_WeightBalance_Passengers.Text);
            List<int> seats = new List<int> { }; numberofSeats = 119;
            if (rdb_WeightBalance_190.Checked == true)
                numberofSeats = 107;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                for (int x = 0; x < passengers; x++)
                {
                    int randomNumber = RandomNumber(1, numberofSeats);
                    while (seats.Contains(randomNumber))
                    {
                        randomNumber = RandomNumber(1, numberofSeats);
                    }
                    seats.Add(randomNumber);
                    UpdateSeat(randomNumber);
                }
            };
            worker.RunWorkerAsync();
        }
        /// <summary>
        /// Update a seat control in the correct UI thread. If this
        /// method is invoked in a thread besides the UI thread it will use
        /// BeginInvoke to put it on the UI thread queue.
        /// </summary>
        /// <param name="seatNumber"></param>
        private void UpdateSeat (int seatNumber)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)(() => UpdateSeat(seatNumber)));
            }
            else
            {
                Control[] seat = this.Controls.Find("img_Seat_" + seatNumber, true);
                seat[0].Visible = true;
            }
        }
