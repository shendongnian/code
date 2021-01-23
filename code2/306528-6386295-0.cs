    private int SelectId(string tabela, string campo, string valor)
        {
            int id = 0;
            using (command = new MySqlCommand())
            {
                command.Connection = conn;
                command.Parameters.Add("@campo", MySqlDbType.Text).Value = campo;
                command.Parameters.Add("@valor", MySqlDbType.VarChar).Value = valor;
                // TODO:  Validate table name for parameter 'tabela' to prevent SQL injection
                // TODO:  Validate column name for parameter 'campo' to prevent SQL injection
                command.CommandText = "SELECT `id` FROM " + tabela + " WHERE @campo=@valor;";
                try
                {
                    id = (int)command.ExecuteScalar();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Number + " : " + ex.Message + command.CommandText);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return id;
        }
