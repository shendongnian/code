        private void OpCode()
        {
             if (string.IsNullOrWhiteSpace(comboBox1.SelectedValue.ToString()))
             {
                MessageBox.Show("Please select a value in the drop down.");
                return;
             }
            DB DataClass = new DB();
            dataGridView1.DataSource = DataClass.GetCountryData(comboBox1.SelectedValue.ToString());
        }
