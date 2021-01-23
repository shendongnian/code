    private void textBox2_TextChanged(object sender, EventArgs e)
            {
                if (textBox2.Text == "0")
                {
                    if (comboBox1.Items.Count > 0)
                          comboBox1.Items.Clear();
                    comboBox1.Items.Insert(0,"Mr");
                    comboBox1.Items.Insert(1, "Dr");
                }
                else if (textBox2.Text == "1")
                {
                    if (comboBox1.Items.Count > 0)
                          comboBox1.Items.Clear();
                    comboBox1.Items.Add("Ms");
                    comboBox1.Items.Add("Mrs");
                    comboBox1.Items.Add("Miss");
                }
            }
