		private void PopulateAccountTypes()
		{
			try
			{
				string accountQuery = "SELECT AccountType FROM AccountType WHERE UserID = " + MyAccountant.DbProperties.currentUserID + "";
				SqlDataReader accountType = null;
				SqlCommand query = new SqlCommand(accountQuery, MyAccountant.DbProperties.dbConnection);
				accountType = query.ExecuteReader();
				while (accountType.Read())
				{
					this.Types.Add(accountType["AccountType"].ToString());
				}
				accountType.Close();
				Resources["types"] = this.Types;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
