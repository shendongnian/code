this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_Changed);
In the Form.cs file:
 private void dataGridView1_Changed(object sender, EventArgs e)
        {
            bsTable.DataSource = bsAirplanes.Current; //notice I am using bsAirplanes.Current, not bsAirplanes
            bsTable.DataMember = "Table";
            dataGridView2.DataSource = bsTable;
            dataGridView2.AutoGenerateColumns = true;
        }
