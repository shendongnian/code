    using (SqlConnection conn = new SqlConnection())
    {
         conn.Open();
         for (int i = 0; i < checkedComboBox1.Items.Count; i++)
         {
             using (SqlCommand cmd = new SqlCommand())
             {
                 cmd.Connection = conn;
                 bool isChecked = checkedComboBox1.GetItemChecked(i);
                 string colour = checkedComboBox1.Items[i].ToString();
                 cmd.CommandText = $"UPDATE TableName SET [{colour}] = '{(isChecked ? 1 : 0)}'";
                 cmd.ExecuteNonQuery();
              }
         }
         conn.Close();
    }
