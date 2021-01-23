    private void btnPause_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                _CountdownTimer.Pause();
            }
        }
