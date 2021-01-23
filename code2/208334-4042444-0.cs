    string query = string.Format("SELECT TotalAmount, Discount, SpecialDiscount, Tax, NetAmount {0} From SomeTable", GetUserFormula(userName, tableName));
    private string GetUserFormula(string userName, string tableName)
        {
            StringBuilder result = new StringBuilder();
            using (SqlConnection con = new SqlConnection("someConnectionString"))
            {
                using (SqlCommand com = new SqlCommand("Select FormulaText, FormulaHeading FROM Formula WHERE UserName = @userName AND TableName =@TableName"))
                {
                    com.Parameters.AddWithValue("userName", userName);
                    com.Parameters.AddWithValue("tableName", tableName);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader == null)
                        return result.ToString();
                    while (reader.NextResult())
                    {
                        result.AppendFormat(", ({0}) AS [{1}]", reader["FormulaText"], reader["FormulaHeading"]);
                    }
                    return result.ToString();
                }
            }
        }
