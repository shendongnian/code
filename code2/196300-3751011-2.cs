    private void button1_Click(object sender, EventArgs e) 
    { 
    
    string dateString = string.Format("{0}/{1}/{2} {3}:{4}:{5}", M.Text,dd.Text,yyyy.Text, hh.Text, mm.Text, ss.Text); 
    long ticks = Convert.ToDateTime(dateString).Ticks;
    long microseconds = ticks / 10;
    convertedText.Text = microseconds.ToString("X");        
    } 
       
    
