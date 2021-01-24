     if (comboBox1.SelectedItem.ToString() == "USB_RS232")
            {
                var nameDT = (from names in USB_RS232.AsEnumerable()
                              where names.Field<string>("MODEL") != null
                              select names.MODEL);
                datatable = USB_RS232;
                var cleanList = nameDT.Distinct().ToArray();
                foreach (var item in cleanList)
                {
                    comboBox2.Items.Add(item);
                }
            }
            dataGridView1.Columns.Clear();
            foreach (DataColumn item in datatable.Columns)
            {
                var colname = item.ColumnName.ToString();
                dataGridView1.Columns.Add(colname, colname);
            }
