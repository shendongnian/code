    comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_IndexChanged);
    private void comboBox1_IndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Remove("Select Source");
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox1.SelectedIndex == 0) // File
                {
                    // Do things
                }
                else if (comboBox1.SelectedIndex == 1) // Folder
                {
                    // Do things
                }
            }
        }
