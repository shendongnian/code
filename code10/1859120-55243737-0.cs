     private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            sqliteCon.Open();
            if (sqliteCon.State == System.Data.ConnectionState.Open)
            {
                var currentRowIndex = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);//PER IDENTIFICARE LA LINEA CORRENTE
                string q = @"UPDATE tabList
                             SET selection = (CASE 
                                                WHEN (SELECT selection FROM tabList where idL = @CURRENT) = 0
                                                THEN 1
                                                ELSE 0
                                              END)
                             WHERE idL = @CURRENT";
                SqlCommand cmd = new SqlCommand(q, sqliteCon);
                currentRowIndex = currentRowIndex + 1;
                cmd.Parameters.AddWithValue("@CURRENT", currentRowIndex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dato Modificato");
            }
            sqliteCon.Close();
        }
