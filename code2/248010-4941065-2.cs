    //Declare this private variable to hold the color selected by the user
    private System.Drawing.Color selectedcolor;    
    private void SelectColor_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedcolor = colorDialog1.Color; // BackColor stored in variable
        }
    }
