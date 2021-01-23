            for (int i = 0; i < values.Length; i++)
            {
                query.Append("@" + i.ToString()); // instead of query.Append("@" + values[i].ToString());
                if (i < values.Length - 1)
                {
                    query.Append(",");
                }
            }
            query.Append(")");
            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + i.ToString(), values[i]); // instead of cmd.Parameters.AddWithValue("@" + values[i].ToString(), values[i]);
                }
                rowsAffected = cmd.ExecuteNonQuery();
            }
        }
