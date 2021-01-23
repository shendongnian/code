    public void On_textbox1TextChanged(object sender, EventArgs e)
    {
       Double dblVal = 0;
       if(Double.TryParse(this.textbox1.Text, ref dblVal))
       {
          this.textbox1.Text = dblVal.ToString("N2"); // Prints two 2 decimal places
       }
       else { /* Handle invalid value */ }
    }
