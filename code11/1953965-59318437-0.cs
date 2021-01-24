    private void Button2_Click(object sender, EventArgs e)
    {
        // we modify control...
        function1(label1);
    }
    
    private void function1(Control ctrl)
    {
        if (var1)
        {
            // ... control's Text to be exact
            ctrl.Text = "Yeaaah!";
        }
    }
