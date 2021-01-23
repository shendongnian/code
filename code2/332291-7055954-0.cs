    There're two ways to do this:
    
    1). Cast a DataGridViewCell to a certain cell type that exists. For example, convert a DataGridViewTextBoxCell to DataGridViewComboBoxCell type.
    2). Create a control and add it into the controls collection of DataGridView, set its location and size to fit the cell that to be host.
     
    See my sample code below which illustrates the tricks.
    
    Code Snippet
    private void Form5_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                for (int j = 0; j < 10; j++)
                {
                    dt.Rows.Add("");
                }
                this.dataGridView1.DataSource = dt;
                this.dataGridView1.Columns[0].Width = 200;
     
                /*
                 * First method : Convert to an existed cell type such ComboBox cell,etc
                 */
     
                DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
                ComboBoxCell.Items.AddRange(new string[] { "aaa","bbb","ccc" });
                this.dataGridView1[0, 0] = ComboBoxCell;
                this.dataGridView1[0, 0].Value = "bbb";
     
                DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
                this.dataGridView1[0, 1] = TextBoxCell;
                this.dataGridView1[0, 1].Value = "some text";
     
                DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1[0, 2] = CheckBoxCell;
                this.dataGridView1[0, 2].Value = true;
     
                /*
                 * Second method : Add control to the host in the cell
                 */
                DateTimePicker dtp = new DateTimePicker();
                dtp.Value = DateTime.Now.AddDays(-10);
                //add DateTimePicker into the control collection of the DataGridView
                this.dataGridView1.Controls.Add(dtp);
                //set its location and size to fit the cell
                dtp.Location = this.dataGridView1.GetCellDisplayRectangle(0, 3,true).Location;
                dtp.Size = this.dataGridView1.GetCellDisplayRectangle(0, 3,true).Size;
            }
