    DataSet data = new DataSet();
                data.ReadXml("C:\\xml.xml");
                this.dataGridView1.DataSource = data;
                this.dataGridView1.DataMember = "customer";
                foreach (DataGridViewColumn column in this.dataGridView1.Columns)
                {
                    if (column.Name == "ID" || column.Name == "name")
                        column.Visible = true;
                    else
                       column.Visible = false;
    
                }
