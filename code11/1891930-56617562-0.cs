        private void ComboBoxParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numComboBoxes = 5;
            for (int i = 0; i < numComboBoxes; i++)
            {
                ComboBox comboBoxChild = new System.Windows.Forms.ComboBox();
                comboBoxChild.Location = new System.Drawing.Point(0, 21 * i);//Position on the Form
                comboBoxChild.Size = new System.Drawing.Size(121, 21);//Size of the ComboBox
                this.Controls.Add(comboBoxChild);
            }
        }
