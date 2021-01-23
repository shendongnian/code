    //
    //  Preferrably, you can put PrintDialog component using Tooblox Palette
    //  it will allows you to configure component properties in the objects's Proerty Editor
    //private PrintDialog dialog = new PrintDialog();
    
    private void printerToolStripButton_Click(object sender, EventArgs e)
    {
        if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            // do some stuff here...
        }
    }
