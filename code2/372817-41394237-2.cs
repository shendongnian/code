    SqlDataAdapter dAdapter = new SqlDataAdapter(new SqlCommand("SELECT Photo FROM Image", conn));
            DataSet dSet = new DataSet();
            dAdapter.Fill(dSet);
            if (dSet.Tables[0].Rows.Count == 1)
            {
                Byte[] data = new Byte[0];
                data = (Byte[])(dSet.Tables[0].Rows[0]["Photo "]);
                MemoryStream mem = new MemoryStream(data);
                PictureBoxName.Image = Image.FromStream(mem);
             }
