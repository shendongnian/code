    while (dr.Read())
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            subjob.Items.Add(dr[0]);
        }
    }
