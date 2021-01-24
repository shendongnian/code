    private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
    
            var random = new Random();
            computer = random.Next(1,4);            
    
            if (computer == 1)
                pictureBox1.Visible = true;
                label8.Text = "Tie!";                               
        }          
