    private void generate_Click(object sender, EventArgs e)
            {
                int val = 0;
    
                if (Int32.TryParse(dd.Text, out val))
                {
                    if (val > 31) return;
                    else if (dd.Text.Length <= 1)
                        return;
                }
                else 
                {
                     return;
                }
    
                if (Int32.TryParse(MM.Text, out val))
                {
                    if (val > 31) return;
                    else if (MM.Text.Length <= 1)
                        return;
                }
                else 
                {
                     return;
                }
    
                if (Int32.TryParse(hh.Text, out val))
                {
                    if (val > 31) return;
                    else if (hh.Text.Length <= 1)
                        return;
                }
                else 
                {
                     return;
                }
    
                if (Int32.TryParse(M.Text, out val))
                {
                    if (val > 31) return;
                    else if (M.Text.Length <= 1)
                        return;
                }
                else 
                {
                     return;
                }
    
                if (Int32.TryParse(ss.Text, out val))
                {
                    if (val > 31) return;
                    else if (ss.Text.Length <= 1)
                        return;
                }
                else 
                {
                     return;
                }
    
                String dateString = yyyy.Text + dd.Text + MM.Text + hh.Text + M.Text + ss.Text;
                DateTime timestamp = DateTime.ParseExact(dateString, "yyyyddMMhhmmss", CultureInfo.CurrentCulture);
                long ticks = timestamp.Ticks;
                long microseconds = ticks / 10;
                convertedText.Text = microseconds.ToString("X");
            }
