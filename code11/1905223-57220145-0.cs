            using (SqlConnection con = new SqlConnection("your connection string"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [column_you_want] FROM [rights] WHERE [user] = @user"))
                {
                    cmd.Parameters.AddWithValue("@user", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    con.Open();
                    int right = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
