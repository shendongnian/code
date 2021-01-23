     AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();
            private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                String strConn = "Server = .;Database = NorthWind; Integrated Security = SSPI;";
                SqlConnection conn = new SqlConnection(strConn);
                SqlDataAdapter da = new SqlDataAdapter("Select * from [Order Details]", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                for (int x = 1; x <= 61000; x++ )
                {
                    scAutoComplete.Add(x.ToString());
                }
            }
            private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (dataGridView1.CurrentCellAddress.X == 1)
                {
                    TextBox txt = e.Control as TextBox;
                    txt.AutoCompleteCustomSource = scAutoComplete;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
                if(e.ColumnIndex==1)
                {
                    if(!scAutoComplete.Contains(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("Invalid Data");
                        e.Cancel=true;
                    }
                }
            }
