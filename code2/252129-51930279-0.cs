    //click event on the button to change the color of the label
    public void buttonColor_Click(object sender, EventArgs e)
            {
                Timer timer = new Timer();
                timer.Interval = 500;// Timer with 500 milliseconds
                timer.Enabled = false;
    
                timer.Start();
    
                timer.Tick += new EventHandler(timer_Tick);
            }
    
           void timer_Tick(object sender, EventArgs e)
        {
            //label text changes from 'Not Connected' to 'Verifying'
            if (labelFirst.BackColor == Color.Red)
            {
                labelFirst.BackColor = Color.Green;
                labelFirst.Text = "Verifying";
            }
    
            //label text changes from 'Verifying' to 'Connected'
            else if (labelFirst.BackColor == Color.Green)
            {
                labelFirst.BackColor = Color.Green;
                labelFirst.Text = "Connected";
            }
    
            //initial Condition (will execute)
            else
            {
                labelFirst.BackColor = Color.Red;
                labelFirst.Text = "Not Connected";
            }
        }
