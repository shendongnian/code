    private bool WithErrors()
    {
        if(textBox1.Text.Trim() == String.Empty) 
            return true; // Returns true if no input or only space is found
        if(textBox2.Text.Trim() == String.Empty)
            return true;
        // Other textBoxes.
        
        return false;
    }
    
    private void buttonSubmit_Click(object sender, EventArgs e)
    {
        if(WithErrors())
        {
            // Notify user for error.
        }
        else
        {
            // Do whatever here... Submit
        }
    }
