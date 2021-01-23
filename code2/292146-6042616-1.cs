    SqlDataReader puanoku = cmd2.ExecuteReader();
    List<int> puann = new List<int>();
    while (puanoku.Read())
    {
        int value = puanoku.GetInt32(1);
        // Do something with the int here...
    }
