    /* !! This clears the textbox BEFORE you check if it's empty */
    MaterialTextBox.Clear();
    
    HoursNumericUpDown.Value = HoursNumericUpDown.Minimum;
    MarkNumericUpDown.Value = MarkNumericUpDown.Minimum;
    
    if (String.IsNullOrEmpty(MaterialTextBox.Text))
    {
            MessageBox.Show("Enter Material Name Please.", "Error", MessageBoxButtons.OK,    MessageBoxIcon.Warning);
                //dataGridView1.Rows.Clear();
    }
