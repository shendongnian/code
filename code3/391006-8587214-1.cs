    using (SqlCommand update = new SqlCommand("Update Table_065_Turn SET Column02=@Col2, Column15=@Col15 where ColumnId=@ColId", con))
    {
        update.Parameters.AddWithValue("@Col2", Row["Column48"]);
        update.Parameters.AddWithValue("@Col15", Row["Column15"]);
        update.Parameters.AddWithValue("@ColId", StatusTable.Rows[0]["ColumnId"]);
        update.ExecuteNonQuery();
    }
