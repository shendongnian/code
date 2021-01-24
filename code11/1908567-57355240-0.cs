    public static void InsertEntries(IEnumerable<UBLGelen> entries)
    {
        using (SqlConnection sqlConnection = new SqlConnection("Data Source=WIZM - W10 - P347ZC;Initial Catalog= WIZM - W10 - P347ZC;Integrated Security=True"))
        {
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                const string Text = "INSERT INTO Entries (ProfileID, ID, UUID, IssueDate, SenderName, VKN, VKNCustomer) VALUES (@ProfileID{0},@ID{0},@UUID{0},@IssueDate{0},@SenderName{0}, @VKN{0},@VKNCustomer{0} );";
                int count = 0;
                string query = string.Empty;
                foreach (var data in entries)
                {
                    query += string.Format(Text, count);
                    cmd.Parameters.AddWithValue(string.Format("@ProfileID {0}", count), data.ProfileID);
                    cmd.Parameters.AddWithValue(string.Format("@ID {0}", count), data.ID);
                    cmd.Parameters.AddWithValue(string.Format("@UUID {0}", count), data.UUID);
                    cmd.Parameters.AddWithValue(string.Format("@IssueDate {0}", count), data.IssueDate);
                    cmd.Parameters.AddWithValue(string.Format("@SenderName {0}", count), data.AccountingSupplierParty.Party.PartyName.FirstOrDefault().Name);
                    cmd.Parameters.AddWithValue(string.Format("@VKN {0}", count), data.AccountingSupplierParty.Party.PartyIdentification.FirstOrDefault().ID);
                    cmd.Parameters.AddWithValue(string.Format("@VKNCustomer {0}", count), data.AccountingCustomerParty.Party.PartyIdentification.FirstOrDefault().ID);
                    count++;
                }
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
    }
