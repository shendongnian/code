            // get path to save file
            string fn = DateTime.Now.ToShortDateString() + " " + cbMaterial.SelectedItem.ToString(); //this combobox is my report name
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = fn.Replace("/","-").Replace(" ","_");
            sfd.Filter = "(*.csv)|*.csv";
            sfd.ShowDialog();
            string path = sfd.FileName;
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;
            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in gvReports.Columns)
            {
                csv += column.HeaderText + ',';
            }
            //Add new line.
            csv += "\r\n";
            //Adding the Rows
            foreach (DataGridViewRow row in gvReports.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }
                //Add new line.
                csv += "\r\n";
            }
            if (sfd.FileName != null)
            {
                //Exporting to CSV.
                File.WriteAllText(path, csv);
            }
