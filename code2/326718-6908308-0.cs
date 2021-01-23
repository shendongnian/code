    if (dataset1.Tables[0].Rows[0][0].ToString() == "Y")
    {
        for (int i = 0; i < dataset2.Tables[0].Rows.Count - 1; i++)
        {
            dataset1.Tables[0].Rows.Add(dataset2.Tables[0].Rows[i]);
        }
    }
