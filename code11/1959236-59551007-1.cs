            private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled=true;
            pBar.Visible = true;
            pBar.Step = 1;
            pBar.Minimum = 0;
            
            pBar.Maximum = 100;
            for (int j = 1; j < 101; j++)
            {
                // double pow = Math.Pow(j, j); //Calculation
                pBar.Value = j;
                pBar.Value = j-1;
                pBar.PerformStep();
                Thread.Sleep(20);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pBar.Value == 100)
            {
                pBar.Value = 0;
                timer1.Enabled = false; // stop timer process
            }
        }
