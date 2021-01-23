    // holds a copy of the previous value for comparison purposes
    private string oldString = string.Empty; 
    private void button6_Click(object sender, EventArgs e)
    {
        // Get the new string value
        string newString = //some varying value I get from other parts of my program
        
        // Compare the old string to the new one
        if (oldString != newString)
        {
            // The string values are different, so update the ListBox
            listBox1.Items.Clear();
            listBox1.Items.Add(x + /*other things*/);   
        }
        // Save the new value back into the temporary variable
        oldString = newString;
    }
