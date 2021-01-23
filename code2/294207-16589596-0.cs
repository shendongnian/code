        private void clearRecursive(Control control)
        {
            foreach (Control subcontrol in control.Controls)
            {
                if (subcontrol is TextBox)
                {
                    TextBox textBox = (TextBox)subcontrol;
                    textBox.Text = null;
                }
                if (subcontrol is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)subcontrol;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }
                if (subcontrol is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)subcontrol;
                    checkBox.Checked = false;
                }
                if (subcontrol is ListBox)
                {
                    ListBox listBox = (ListBox)subcontrol;
                    listBox.Items.Clear();
                }
                if (subcontrol is CheckedListBox)
                {
                    CheckedListBox chklstbox = (CheckedListBox)subcontrol;
                    for (int i = 0; i < chklstbox.Items.Count; i++)
                    {
                        chklstbox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                clearRecursive(subcontrol);
            }           
        }
