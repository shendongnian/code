    string blueChecked = checkedComboBox1.GetItemChecked(0) ? "1" : "0";
    string redChecked = checkedComboBox1.GetItemChecked(1) ? "1" : "0";
    string orangeChecked = checkedComboBox1.GetItemChecked(2) ? "1" : "0";
    string pinkChecked = checkedComboBox1.GetItemChecked(3) ? "1" : "0";
    string whiteChecked = checkedComboBox1.GetItemChecked(4) ? "1" : "0";
    string greyChecked = checkedComboBox1.GetItemChecked(5) ? "1" : "0";
    using (SqlConnection conn = new SqlConnection())
    {
         conn.Open();
         using (SqlCommand cmd = new SqlCommand())
         {
              cmd.Connection = conn;
              cmd.CommandText = $"INSERT INTO Colors VALUES ({blueChecked}, {redChecked}, {orangeChecked}, " +
              $"{pinkChecked}, {whiteChecked}, {greyChecked})";
              cmd.ExecuteNonQuery();
         }
         conn.Close();
    }
