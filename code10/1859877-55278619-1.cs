    foreach (object exercise in clbXcercises.CheckedItems)
    {
        using (connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            command.Parameters.AddWithValue("@DayId", scrollBarDays.Value);
            command.Parameters.AddWithValue("@ExerciseId", exercise.ToString());
            DataTable data = new DataTable();
            adapter.Fill(data);
            lsBoxDailyX.DataSource = data;
            lsBoxDailyX.DisplayMember = "Naam";              
        }
        DailyX();
    }
