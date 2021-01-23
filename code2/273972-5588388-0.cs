    for (int i = 1; i < 7; i++)
    {
    	double value = 0;
    	string input = reader.ReadLine(44).Substring(8 * i, 8);
    	
    	if (Double.TryParse(input, out value))
    	{
    		richTextBox1.Text += value.ToString() + "\n";  
    	}
    	else
    	{
    		richTextBox1.Text = "Invalid double entered.";
    	}
    }
