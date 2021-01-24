    private int cx;
    private List<TextBox> DynamicTextBoxesList = new List<TextBox>();
    
    private void btnAction_Click(object sender, EventArgs e)
    {
        TextBox tbxdg = new TextBox();
        tbxdg.Name = "tbx_DG" + cx.ToString();
        tbxdg.Location = new Point(508, 12 + (40 * cx));
        tbxdg.Size = new Size(200, 24);
        tbxdg.Font = new Font("Tahoma", 10);
        panel2.Controls.Add(tbxdg);
        // add to list
        DynamicTextBoxesList.Add(tbxdg);
        cx++;
    }
    
    // button event for example how to use DynamicTextBoxesList
    private void btnExampleFoaccesingTextBoxes_Click(object sender, EventArgs e)
    {
        if (DynamicTextBoxesList.Count > 0)
        {
            foreach (TextBox t in DynamicTextBoxesList)
            {
                MessageBox.Show(t.Text);
            }
    
            // or you can find by name for example you need cx=1:
            var txtbox = DynamicTextBoxesList.Where(x => x.Name == "tbx_DG1").FirstOrDefault();
            if (txtbox != null)
            {
                MessageBox.Show(txtbox.Text);
            }
        }
    }
