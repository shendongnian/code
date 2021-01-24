    public enum TableName
    {
        Users = 0,
        Registration,
        TheTamThoi
    }
Create a function to do that, `InsertWithImage`:
        public string InsertWithImage(TableName tableName, string[] fields, string[] values)
        {
            try
            {
                Connect();
                SqlCommand command;
                SqlDataAdapter adapter;
                string commandText = string.Empty;
                string table = string.Empty;
                switch (tableName)
                {
                    case TableName.Users:
                        table = "TBUsers";
                        break;
                    case TableName.Registration:
                        table = "TBRegistration";
                        break;
                    case TableName.TheTamThoi:
                        table = "TBTheTamThoi";
                        break;
                    default:
                        break;
                }
                StringBuilder builder = new StringBuilder($"INSERT INTO [dbo].[{table}](");
                for (int i = 0; i < fields.Length; i++)
                {
                    builder.Append(i == fields.Length - 1 ? $"[{fields[i]}]) VALUES(" : $"[{fields[i]}],");
                }
                for (int i = 0; i < values.Length; i++)
                {
                    builder.Append(i != values.Length - 1 ? $"@{fields[i]}, " : $"@{fields[i]})");
                }
                commandText = builder.ToString();
                command = new SqlCommand(commandText, sqlConnection);
                for (int i = 0; i < values.Length; i++)
                {
                    if (fields[i] == "HinhAnh")
                        command.Parameters.AddWithValue(fields[i], string.IsNullOrEmpty(values[i]) ? (object)DBNull.Value : GetData(values[i])).SqlDbType = SqlDbType.Image;
                    else
                        command.Parameters.AddWithValue(fields[i], values[i]);
                }
                adapter = new SqlDataAdapter(command);
                adapter.InsertCommand = new SqlCommand(commandText, sqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                sqlConnection.Close();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
Done.
