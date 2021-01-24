    private void Process_MouseEnter(object sender, EventArgs e)
    {
        Control control = sender as Control;
    
        if (control != null)
        {
           /* do both label and Panel stuff here */
           if (sender is Panel)
           {
              Panel p = sender as Panel;
              /* Do Panel stuff here
           }
           if (sender is Label)
           {
              Label l = sender as Label;
              /* Do Label stuff here */
           }
    
        }
    }
