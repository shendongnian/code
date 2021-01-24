    // Check box to toggle decimal places to be displayed.
    
    private void checkBox1_Click(Object sender, EventArgs e)
    {
       /* If DecimalPlaces is greater than 0, set them to 0 and round the 
          current Value; otherwise, set DecimalPlaces to 2 and change the 
          Increment to 0.25. */
       if (numericUpDown1.DecimalPlaces > 0)
       {
          numericUpDown1.DecimalPlaces = 0;
          numericUpDown1.Value = Decimal.Round(numericUpDown1.Value, 0);
       }
       else
       {
          numericUpDown1.DecimalPlaces = 2;
          numericUpDown1.Increment = 0.25M;
       }
    }
