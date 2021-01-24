    SqlDataAdapter sqladapter = new SqlDataAdapter($"{getSqlTypes}", form1.conn = new SqlConnection($"Server = {form1.ServerBox.Text }; Database = { form1.DBBox.Text}; Trusted_Connection = True"));
                    DataSet dt = new DataSet();
                    sqladapter.Fill(dt);
                    labels[i] = new Label();
                    labels[i].Text = dt.Tables[0].Rows[0][0].ToString();
                    tableLayoutPanel.SetCellPosition(labels[i], new TableLayoutPanelCellPosition(2, k++));
                    tableLayoutPanel.Controls.Add(labels[i]);
                    getSqlTypes = $"SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{comboBox1.SelectedItem}' AND COLUMN_NAME = ";
