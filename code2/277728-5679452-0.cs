    for (int i = 0; i < 5; i++)
    {
        using (var conn = new SqlConnection("Some Connection String"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "INSERT INTO foo (...) VALUES (...)";
            cmd.Parameters["Mon1"].Value = newTA.MonAry[i];
            cmd.Parameters["Tue1"].Value = newTA.TueAry[i];
            cmd.Parameters["Wed1"].Value = newTA.WedAry[i];
            cmd.Parameters["Thu1"].Value = newTA.ThuAry[i];
            cmd.Parameters["Fri1"].Value = newTA.FriAry[i];
            cmd.ExecuteNonQuery();
        }
    }
