    private void NumericUpDown1_Validated(object sender, EventArgs e)
    {
        _foo.Value = numericUpDown1.Value;
    }
    private void ToolStripButton1_Click(object sender, EventArgs e)
    {
        this.Validate();
        _foo.Save();
    }
