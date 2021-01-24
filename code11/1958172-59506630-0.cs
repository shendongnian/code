        private void AddToDatabase()
        {
            using (SqlConnection con = new SqlConnection("server= localhost;Database = Vehiculum ;integrated Security = true"))
            using (SqlCommand cmd = new SqlCommand("inserproducts", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mbiemri", SqlDbType.VarChar, 50).Value = txtmbiemri.Text; 
                cmd.Parameters.Add("@telefoniI", SqlDbType.VarChar, 50).Value = txttelefoniI.Text; 
                cmd.Parameters.Add("@telefoniII", SqlDbType.VarChar, 50).Value = txttelefoniII.Text; 
                cmd.Parameters.Add("@adresa", SqlDbType.VarChar, 100).Value = txtadresa.Text; 
                cmd.Parameters.Add("@komuna", SqlDbType.VarChar, 50).Value = cmbkomuna.Text; 
                cmd.Parameters.Add("@prodhuesi", SqlDbType.VarChar, 50).Value = cmbprodhuesi.Text; 
                cmd.Parameters.Add("@modeli", SqlDbType.VarChar, 50).Value = cmbmodeli.Text; 
                cmd.Parameters.Add("@motorri", SqlDbType.VarChar, 50).Value = cmbmotori.Text; 
                cmd.Parameters.Add("@shasia", SqlDbType.VarChar, 50).Value = txtshasia.Text; 
                cmd.Parameters.Add("@tabela", SqlDbType.VarChar, 50).Value = txttabela.Text; 
                cmd.Parameters.Add("@viti", SqlDbType.VarChar, 50).Value = txtviti.Text;
                cmd.Parameters.Add("@kategoria", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@servisimi", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@barkodi", SqlDbType.Int);
                cmd.Parameters.Add("@emertimi", SqlDbType.VarChar, -1).Value = txtemri.Text; ;
                cmd.Parameters.Add("@sasia", SqlDbType.Int);
                cmd.Parameters.Add("@garancioni", SqlDbType.VarChar, 200);
                cmd.Parameters.Add("@shenime", SqlDbType.VarChar, -1).Value = txtshenime.Text;
                cmd.Parameters.Add("@data", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@punetori", SqlDbType.VarChar, 100).Value = lbluser.Text;
               
                con.Open();
                for (int i = 0; i < dtgservisimi.Rows.Count -1; i++)
                {
                    cmd.Parameters["@servisimi"].Value = dtgservisimi.Rows[i].Cells[1].Value;
                    cmd.Parameters["@barkodi"].Value = (int)dtgservisimi.Rows[i].Cells[2].Value;
                    cmd.Parameters["@emertimi"].Value = dtgservisimi.Rows[i].Cells[3].Value;
                    cmd.Parameters["@sasia"].Value = (int)dtgservisimi.Rows[i].Cells[4].Value;
                    cmd.Parameters["@garancioni"].Value = dtgservisimi.Rows[i].Cells[5].Value;
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
