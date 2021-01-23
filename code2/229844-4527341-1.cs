    private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Enabled = false;
                if (mClick == 1)
                {
                    mClick = 0;
                    MessageBox.Show("single click");
    
                }
                if (mClick == 2)
                {
                    mClick = 0;
                    MessageBox.Show("double click");
                }
                
            }
