     if (BarreProgression.Value < BarreProgression.Maximum)
            {
                ...
                BarreProgression.Value = BarreProgression.Value + 1;
            }
            else if (BarreProgression.Value == BarreProgression.Maximum)
            {
    
                //AppTimer.Stop();
                AppTimer.Enabled = false;  
                MessageBox.Show("Finished");
            }
