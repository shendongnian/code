    public bool fillComboBox(string connectionString, System.Windows.Controls.ComboBox combobox, string query, string defaultValue, string itemText, string itemValue)
        {
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter sqladp = new SqlDataAdapter();
            DataSet ds = new DataSet();
                try
                {
                    using (SqlConnection _sqlconTeam = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
                    {
                        sqlcmd.Connection = _sqlconTeam;
                        sqlcmd.CommandType = CommandType.Text;
                        sqlcmd.CommandText = query;
                        _sqlconTeam.Open();
                        sqladp.SelectCommand = sqlcmd;
                        sqladp.Fill(ds, "defaultTable");
                        DataRow nRow = ds.Tables["defaultTable"].NewRow();
                        nRow[itemText] = defaultValue;
                        nRow[itemValue] = "-1";
                        ds.Tables["defaultTable"].Rows.InsertAt(nRow, 0);
                    combobox.DataContext = ds.Tables["defaultTable"].DefaultView;
                    combobox.DisplayMemberPath = ds.Tables["defaultTable"].Columns[0].ToString();
                    combobox.SelectedValuePath = ds.Tables["defaultTable"].Columns[1].ToString();                    
                }
                return true;
            }
            catch (Exception expmsg)
            {
                return false;
            }
            finally
            {
                sqladp.Dispose();
                sqlcmd.Dispose();                
            }            
        }
