    SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT pic FROM imageTest WHERE pic_id = 1", yourConnectionReference));
    DataSet dataSet = new DataSet();
    dataAdapter.Fill(dataSet);
    if (dataSet.Tables[0].Rows.Count == 1)
    {
        Byte[] data = new Byte[0];
        data = (Byte[])(dataSet.Tables[0].Rows[0]["pic"]);
        MemoryStream mem = new MemoryStream(data);
        yourPictureBox.Image= Image.FromStream(mem);
    } 
