    int counter = 0;
    private void timer1_Tick(object sender, EventArgs e) { 
        MessageBox.Show("Hello"); 
        counter++; 
        if (counter == 10){
           timer1.Stop();
           timer1.Dispose();
           timer1 = null;
        }
    }
    
