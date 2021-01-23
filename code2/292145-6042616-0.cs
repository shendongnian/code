    SqlDataReader puanoku = cmd2.ExecuteReader();
    List<int> puann = new List<int>();
    while (puanoku.Read())
    {
        for (int i = 0; i < puanoku.FieldCount; i++)
        {
            if (puanoku.GetFieldType(i) == typeof(int))
            {
                // Do something here
            }
        }
    }
