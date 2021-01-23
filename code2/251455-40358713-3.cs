    private void timer1_Tick(object sender, EventArgs e)
        { hr = DateTime.UtcNow.Hour;
            hr = hr + 5;
            min = DateTime.UtcNow.Minute;
            sec = DateTime.UtcNow.Second;
            if (hr > 12)
                hr -= 12;
            if (sec % 2 == 0) 
            {   label1.Text = +hr + ":" + min + ":" + sec; 
            }
            else
            {  label1.Text = hr + ":" + min + ":" + sec;
            }
            //Ash_Bilal( Thanks to see it rate if it solved your problem) 
        }
        
