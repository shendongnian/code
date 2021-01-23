    private void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        // This will assign btn with the properties of the button clicked
        txt_display.Text = txt_display.Text + btn.Text;
        // this will append to the textbox with whatever text value the button holds
    }
