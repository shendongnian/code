    string timeString;
    
    private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //You already declared client, so you don't need to do it again.
    
                //Assign the value from your wcf call to a local variable
                timeString = client.passTime();
            }
            catch
            {
                MessageBox.Show("Service not availabe!");
            }
        }
