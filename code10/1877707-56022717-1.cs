                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from hammaddeler", 
                                   baglanti);
                SqlDataAdapter ad = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                private System.Windows.Forms.DataGridView dataGridView1;
                private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
