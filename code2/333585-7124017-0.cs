        private void button2_Click(object sender, EventArgs e)
        {
            using (CsvReader csv = new CsvReader(new StreamReader(@textBox1.Text), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                /// Evaluate the checkedlistbox
                string comment = "";
                List<Int32> comment_indices = new List<Int32>();
                List<String> lines = new List<String>();
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    // add selected item's index to list
                    comment_indices.Add(checkedListBox1.CheckedIndices[x]);
                }
                while (csv.ReadNextRecord())
                {
                    ///  Use the SelectedIndex to match the header and column
                    string base_string = csv[LONcomboBox.SelectedIndex] + "," + csv[LATcomboBox.SelectedIndex] + "," + csv[NAMEcomboBox.SelectedIndex] + ",";
                    //MessageBox.Show(base_string);
                    ///  Try to get the row value -- this is the row count - starting at 0 excluding headers I think
                    //MessageBox.Show("Is this the row count?" + csv.CurrentRecordIndex);
                    comment = "";
                    ///  Get the comment
                    foreach (Int32 indices in comment_indices)
                    {
                        comment = comment + csv[indices] + " ";
                    }
                    //MessageBox.Show(base_string + '"' + comment + '"');
                    string completed_string = base_string + '"' + comment + '"';
                    lines.Add(completed_string);
                }
                
                StreamWriter writer = new StreamWriter(@textBox2.Text);
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
                writer.Close(); 
            }          
            MessageBox.Show(" Finished Writing file " + "\n" + "\n" + " " + textBox2.Text);
        }
