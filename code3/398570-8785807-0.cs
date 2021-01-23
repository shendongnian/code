    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        e.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
    }
    void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            Console.WriteLine("escape pressed");
            escapePressed = true;
        }
    }
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (!escapePressed)
        {
            Console.WriteLine("do your stuff"); //escape was not pressed.
        }
        else escapePressed = false; //reset the flag
    }
