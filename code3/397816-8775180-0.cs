        private void Space(object sender, EventArgs e)
        {
            SendKeys.Send(txtText.Text.Substring(b++, 1));
            tmrSpace.Interval = random.Next(50, 150);
            if (b == txtText.TextLength)
            {
                tmrSpace.Enabled = false;
                SendKeys.Send("{enter}");
            }
        }
        private void Interval(object sender, EventArgs e)
        {
            if (cbPause.Checked)
            {
                b = 0;
                tmrSpace.Interval = random.Next(50, 150);
                tmrSpace.Enabled = true;
            }
            else
            {
                SendKeys.Send(txtText.Text + "{enter}");
                if (tbType.SelectedTab == tbRange) tmrInterval.Interval = random.Next(int.Parse(nudMin.Value.ToString()), int.Parse(nudMax.Value.ToString()));
            }
        }
