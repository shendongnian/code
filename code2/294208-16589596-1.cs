        private void clearRecursive(Control control)
        {
            foreach (Control subcontrol in control.Controls)
            {
                switch (subcontrol.GetType().ToString().Replace("System.Windows.Forms.", ""))
                {
                    case "TextBox":
                        TextBox textBox = (TextBox)subcontrol;
                        textBox.Text = null;
                        break;
                    case "ComboBox":
                        ComboBox comboBox = (ComboBox)subcontrol;
                        if (comboBox.Items.Count > 0)
                            comboBox.SelectedIndex = 0;
                        break;
                    case "CheckBox":
                        CheckBox checkBox = (CheckBox)subcontrol;
                        checkBox.Checked = false;
                        break;
                    case "RadioButton":
                        RadioButton radioButton = (RadioButton)subcontrol;
                        radioButton.Checked = false;
                        break;
                    case "TreeView":
                        TreeView tv = (TreeView)subcontrol;
                        foreach (TreeNode node in tv.Nodes)
                        {
                            node.Checked = false;
                            CheckChildren(node, false);
                        }
                        break;
                    case "ListBox":
                        ListBox listBox = (ListBox)subcontrol;
                        listBox.Items.Clear();
                        break;
                    case "CheckedListBox":
                        CheckedListBox chklstbox = (CheckedListBox)subcontrol;
                        for (int i = 0; i < chklstbox.Items.Count; i++)
                        {
                            chklstbox.SetItemCheckState(i, CheckState.Unchecked);
                        }
                        break;
                }
                if (subcontrol.HasChildren)
                    clearRecursive(subcontrol);
            }
        }
