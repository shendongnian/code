         private void ComboBoxParent_SelectedIndexChanged(object sender, EventArgs e)
            {
               int numComboBoxes = 5;
               ComboBox SelectedCombo = sender as ComboBox;
                for (int i = 0; i < numComboBoxes; i++)
                  {
                    ComboBox comboBoxChild = new System.Windows.Forms.ComboBox();
                    comboBoxChild.Location = new System.Drawing.Point(0, 21 * i);
                    comboBoxChild.Size = new System.Drawing.Size(121, 21);
                    this.Controls.Add(comboBoxChild);
                    comboBoxChild.SelectedIndex=SelectedCombo.SelectedIndex;
                   }
            }
