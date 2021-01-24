    string[] qc = new string[];
    while (reader.Read())
    {
        // create an array big enough to hold all columns
        string[] qc = new string[sdr.FieldCount];
        // iterate over all columns of your reader
        for (int i = 0; i < reader.FieldCount; i++)
        {
            // if not null, add to array
            if (!string.IsNullOrEmpty(sdr.GetString(i)))
            {
                qc[i] = sdr.GetString(i);
            }
        }
        label1.Text = string.Join("|", qc);
    }
