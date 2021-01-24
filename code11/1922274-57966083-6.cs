    private void Process_MouseEnter(object sender, EventArgs e)
    {
        if (sender is Panel)
        {
            Panel p = sender as Panel;
    
            /* Do Panel logic here */
            . . . .
    
            /* Find child control */
            foreach (Control c in p.Controls)
                if (c is Label)
                {
                    /* Put Label logic here */
                    c.<some Label method> = <some expression>;
                }
        } /* end Panel if */
    
    
        if (sender is Label)
        {
            /* Put label logic here. Code below is just an demonstration only */
            Label l = sender as Label;
            l.Text = (((int)l.Tag) + 1).ToString();
            l.Tag = (int)l.Tag + 1;
            /* Put Panel logic */
            l.Parent.<some Panel method> = <some expression>;
            l.Parent.<some Panel method> = <some expression>;
        } /* end Label if */
    }
