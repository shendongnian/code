    // Random only needs to be created once at the class level
    private Random r = new Random();
    private void button1_Click(object sender, EventArgs e)
    {
        // Do our validation first and exit early if there's invalid input
        // Use int.TryParse to determine if the value is a number (and get the converted value)
        int userFileSize;
        if (!int.TryParse(textBox1.Text, out userFileSize))
        {
            MessageBox.Show("Please Enter A Numeric File Size");
            return;
        }
        // Get a random file size
        int randomFileSize = r.Next(0, 100);
        if (userFileSize < randomFileSize)
        {
            MessageBox.Show("Ha ha your File smol. Mine is: " + randomFileSize);
            this.Close();
        }
        else
        {
            MessageBox.Show("You have big File! Mine is only: " + randomFileSize);
        }
    }
