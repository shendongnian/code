     DataTable tbl = new DataTable()    
    SqlCommand cmd = new SqlCommand("spEstraiPById", cnn); //See at the end for spEstraiPById
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Id",txtNickname.Text);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        { //Add columns to the table
                            tbl.Columns.Add("ID");
                            tbl.Columns.Add("Nome");
                            tbl.Columns.Add("Cognome");
                            tbl.Columns.Add("Residenza");
                            tbl.Columns.Add("Professione");
                            tbl.Columns.Add("Ruolo");
                            tbl.Columns.Add("Società");
    
                            while (rdr.Read())
                            { //from DB to Table
                                DataRow drw = tbl.NewRow();
                                drw["ID"] = rdr["Id"];
                                drw["Nome"] = rdr["Nome"];
                                drw["Cognome"] = rdr["Cognome"];
                                drw["Residenza"] = rdr["Residenza"];
                                drw["Professione"] = rdr["Professione"];
                                drw["Ruolo"] = rdr["Ruolo/Grado"];
                                drw["Società"] = rdr["Società"];
                                tbl.Rows.Add(drw);
                            }
                            foreach (DataRow row in tbl.Rows) //Deleting empty records
                            {
                                for (int col = tbl.Columns.Count - 1; col >= 0; col--)
                                {
                                    if (row.IsNull(col))
                                    {
                                        tbl.Columns.RemoveAt(col);
                                    }
                                }
                                // No need to continue if we removed all the columns
                                if (tbl.Columns.Count == 0)
                                    break;
                            }
                        }
                            gw1.DataSource = tbl;
                            gw1.DataBind();
                            cnn.Close();
    //=Stored Procedure 
    CREATE PROCEDURE spEstraiPbyId
    	@Id int 
    	as
    	begin
    	SELECT * from Persone 
    	join Lavori on Persone.Id = @Id and Lavori.IdPersona=@Id
    	end
