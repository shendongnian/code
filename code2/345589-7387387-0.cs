    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        // Check if there is a note attached to the day (e.Day.Date) which is being 
        // rendered.
        bool hasNote = ....;
 
        // Style cell (which contains the date) if it has a note
        if (hasNote)
        {
           e.Cell.BackColor = System.Drawing.Color.Yellow;
        }
    }
