    int counter = 0;
    private void timer1_Tick(object sender, EventArgs e) { 
        counter++; 
        if (counter == 10){
           timer1.Enabled = false;
        }
        MessageBox.Show("Hello"); 
    }
