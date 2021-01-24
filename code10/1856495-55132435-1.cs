        public void button1_Click_1(object sender, EventArgs e)
        {
            if (TimesTested < 3)
            {
                ReactionTest();
            }
            else
            {
                MessageBox.Show("Your times were: " + Convert.ToString(ReactionTime1) + ", " + Convert.ToString(ReactionTime2) + ", " + Convert.ToString(ReactionTime3));
            }
        }
        public void btnReactionButton_Click(object sender, EventArgs e)
        {
            btnReactionButton.Enabled = false;
            stopwatch.Stop();
            btnReactionButton.BackColor = Color.Red;
            btnReactionButton.Text = "Your time was " + stopwatch.ElapsedMilliseconds + "ms milliseconds";
            ReactionTime = Convert.ToInt32(stopwatch.ElapsedMilliseconds);
            if (TimesTested == 0)
            {
                ReactionTime1 = ReactionTime;
                TimesTested = TimesTested + 1;
            }
            else if (TimesTested == 1)
            {
                ReactionTime2 = ReactionTime;
                TimesTested = TimesTested + 1;
            }
            else if (TimesTested == 2)
            {
                ReactionTime3 = ReactionTime;
                TimesTested = TimesTested + 1;
            }
        }
        public async void ReactionTest()
        {
            stopwatch.Reset();
            btnReactionButton.Text = "3";
            await Task.Delay(1000);
            btnReactionButton.Text = "2";
            await Task.Delay(1000);
            btnReactionButton.Text = "1";
            await Task.Delay(1000);
            btnReactionButton.Text = "0";
            await Task.Delay(1000);
            btnReactionButton.Text = "Press this button when it turns green";
            await Task.Delay(random.Next(3000, 10000));
            btnReactionButton.Visible = true;
            stopwatch.Start();
            btnReactionButton.BackColor = Color.Green;
            btnReactionButton.Text = "Click Now!";
            btnReactionButton.Enabled = true;
        }
