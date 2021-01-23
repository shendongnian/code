    if (e.KeyCode == Keys.Enter)
            {
                if (textChangedFlag )
                {
                    if(comboBox1.SelectedIndex>=0)
                    {
                        int index = comboBox1.SelectedIndex;
                        comboBox1.Items[index] = comboBox1.Text;
                        textChangedFlag = false;
                    }
                }
            }
