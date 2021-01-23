    private void button1_Click(object sender, EventArgs e)
    {
        double rental;
    
        var dayRental = dayrental();
    
        if(checkBox1.Checked == true)
           rental = dayrental * 19.95;
        
        label4.Text = Convert.ToString(rental);  
    }
        
    private void label4_Click(object sender, EventArgs e)
    {
        
    }
    
    public int dayrental()
    {
         var timeSpan = dateTimePicker2.Value - dateTimePicker1.Value;
         
         var rentalDays = timeSpan.Days;                      
        
         return rentalDays;
    }
