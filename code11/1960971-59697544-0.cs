    private void hijriDate_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
              
                    {
                    greDate.Text = date.HijriToGreg(hijriDate.Text);
                    int age = (int)((DateTime.Now - Convert.ToDateTime(greDate.Text)).TotalDays / 365.242199);
                    textAge.Text =  age.ToString();
                    greDate.Focus();
                }
                
            }
