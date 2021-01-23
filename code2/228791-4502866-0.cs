    string sql = "SELECT dscr FROM system_settings WHERE setting IN ({0})";
    string[] paramArray = settingList.Select((x, i) => "@settings" + i).ToArray();
    cmd.CommandText = string.Format(sql, string.Join(",", paramArray));
    for (int i = 0; i < settingList.Count; ++i)
    {
        cmd.Parameters.Add(new SqlParameter("@settings" + i, settingList[i]));
    }
