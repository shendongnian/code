                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from hammaddeler", 
                                   baglanti);
                SqlDataAdapter ad = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
