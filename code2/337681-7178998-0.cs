    public void InstantiateMyNumericUpDown()
    {
       // Create and initialize a NumericUpDown control.
       numericUpDown1 = new NumericUpDown();
    
       // Dock the control to the top of the form.
       numericUpDown1.Dock = System.Windows.Forms.DockStyle.Top;
    
       // Set the Minimum, Maximum, and initial Value.
       numericUpDown1.Value = 100;
       numericUpDown1.Maximum = 999999;
       numericUpDown1.Minimum = 100;
    
       // Add the NumericUpDown to the Form.
       Controls.Add(numericUpDown1);
    }
