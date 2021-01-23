       private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                checkBox1.BackColor = Color.Green;
    
                Application.DoEvents();
                TimeSpan ts = new TimeSpan();
    
                do
                {
                  
                }
                while (ts.Milliseconds == 2000);
    
                checkBox1.BackColor = SystemColors.Control;
            }
