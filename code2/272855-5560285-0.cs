    private void btnPoint_Click(object sender, EventArgs e)     
    {         
        if (!txtDisplay.Text.Contains("."))
        {
            txtDisplay.Text = txtDisplay.Text + btnPoint.Text;    
        } 
    } 
