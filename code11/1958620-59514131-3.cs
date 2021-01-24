        private void OpCode()
        {
             if (comboBox1.SelectedIndex < 0)
             {
                MessageBox.Show("Please select a value in the drop down.");
                return;
             }
            DB DataClass = new DB();
            dataGridView1.DataSource = DataClass.GetCountryData(comboBox1.SelectedValue.ToString());
        }
