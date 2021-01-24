        private void hijriDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                greDate.Text = new Dates().HijriToGreg(hijriDate.Text);
            }
        }
        private void greDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                hijriDate.Text = new Dates().GregToHijri(greDate.Text);
            }
        }
