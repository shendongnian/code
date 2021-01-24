     private void Btn_AddToLibary_Click(object sender, RoutedEventArgs e)
            {
                sqlConnection.Open();
                SqlCommand com = new SqlCommand("INSERT into tblPurchasedGames (UserID, GameID)" + "values(@UserID, @GameID)", sqlConnection);
                com.Parameters.AddWithValue("@UserID",UserID.Text.Trim());
                com.Parameters.AddWithValue("@GameID",GameID.Text.Trim());
                com.ExecuteNonQuery();
                sqlConnection.Close();
            }
