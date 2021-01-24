    using (MySqlDataAdapter sda = new MySqlDataAdapter(@"SELECT DISTINCT Name FROM articles", MyConnexion))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DTG_Bordereau.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                DTG_Bordereau.Columns[0].DataPropertyName = "Name";
           
                DTG_Bordereau.Columns[3].Width = 300;
                DTG_Bordereau.DataSource = dt;
           
                
               
                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            QuantiteDisponible.Items.Clear();
           
                        MySqlDataAdapter sda2 = new MySqlDataAdapter("SELECT DISTINCT CONCAT(Quantite ,'PCS -' ,Date) as Conc FROM articles where Name='" + dt.Rows[i][0].ToString() + "'", MyConnexion);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        QuantiteDisponible.DataSource = dt2;
                        QuantiteDisponible.DisplayMember = "Conc";
                        QuantiteDisponible.ValueMember = "Conc";
                    }
                }
           
                    catch
                    { }
                
            }
