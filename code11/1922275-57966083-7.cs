    private void Process_MouseEnter(object sender, EventArgs e)
    {
        if (sender is Panel)
        {
            Panel p = sender as Panel;
    
            /* Place Panel logic here */
            p.<some Panel method> = <some expression>
    
            /* Find child control */
            foreach (Control c in p.Controls)
                if (c is Label)
                {
                    /* Place Label logic here */
                    c.<some Label method> = <some expression>;
                }
        } /* end Panel if */
    
    
        if (sender is Label)
        {
            /* Place label logic here. Below Demonstrates away to add */
            Label l = sender as Label;
            l.Text = (((int)l.Tag) + 1).ToString();
            l.Tag = (int)l.Tag + 1;
            /* Place Panel logic */
            l.Parent.<some Panel method> = <some expression>;
        } /* end Label if */
    }
