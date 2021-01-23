    // Aggiorna
        protected void Button1_Click(object sender, EventArgs e)
        {
            cod = Request["cod"];
            //Componiamo la stringa di interrogazione al database relativa alla tabella b_prestiti
            qry = "UPDATE b_libri SET codice='" + TextBox1.Text + "' WHERE codice='" + cod + "'";
            string qry2 = "SELECT codice_libro FROM b_prestiti WHERE codice_libro='" + cod + "'";
            string qry3 = "UPDATE b_prestiti SET codice_libro='" + TextBox1.Text + "' WHERE codice_libro='" + cod + "'";
            string qry4 = "UPDATE b_libri SET titolo='" + TextBox2.Text + "' WHERE codice='" + cod + "'";
            string qry5 = "UPDATE b_libri SET autore='" + TextBox3.Text + "' WHERE codice='" + cod + "'";
            string qry6 = "UPDATE b_libri SET editore='" + TextBox4.Text + "' WHERE codice='" + cod + "'";
            //Creiamo gli oggetti di tipo OleDbConnection
            //passando la stringa di connessione al costruttore
            conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OleDbConnection conn2 = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OleDbConnection conn3 = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //Inizializziamo gli oggetti di tipo OleDbCommand
            cmd = conn.CreateCommand();
            OleDbCommand cmd2 = conn2.CreateCommand();
            OleDbCommand cmd3 = conn3.CreateCommand();
            OleDbDataReader reader2 = null;
            OleDbDataReader reader3 = null;
            //Apriamo la connessione
            conn.Open();
            conn2.Open();
            conn3.Open();
            cmd2.CommandText = qry2;
            reader2 = cmd2.ExecuteReader();
            if (changed)
            {
                if (MessageBox.Show("Sei sicuro di voler aggiornare questo libro?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (first_titolo != TextBox2.Text)
                    {
                        cmd.CommandText = qry4;
                        reader = cmd.ExecuteReader();
                        reader.Close();
                        MessageBox.Show("Titolo Aggiornato!");
                    }
                    if (first_autore != TextBox3.Text)
                    {
                        cmd.CommandText = qry5;
                        reader = cmd.ExecuteReader();
                        reader.Close();
                        MessageBox.Show("Autore Aggiornato!");
                    }
                    if (first_editore != TextBox4.Text)
                    {
                        cmd.CommandText = qry6;
                        reader = cmd.ExecuteReader();
                        reader.Close();
                        MessageBox.Show("Editore Aggiornato!");
                    }
                    if (first_codice != TextBox1.Text)
                    {
                        while (reader2.Read())
                        {
                           if (reader2["codice_libro"] != "")
                           {
                                if (MessageBox.Show("VINCOLI REFERENZIALI! Vuoi aggiornare comunque?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    
                                    //reader3.Close();
                                    cmd.CommandText = qry;
                                    cmd3.CommandText = qry3;
                                    reader3 = cmd3.ExecuteReader();
                                    reader = cmd.ExecuteReader();
                                    
                                    
                                   // reader.Close();
                                    MessageBox.Show("Vincolo Aggiornato!");
                                }
                                else Response.Redirect("Default.aspx");
                           }
                           else 
                           {
                                cmd3.CommandText = qry3;
                                reader3 = cmd3.ExecuteReader();
                               reader3.Close();
                                Response.Redirect("Default.aspx");
                            }
                        }
                       
                        cmd.CommandText = qry;
                        reader = cmd.ExecuteReader();
                        reader.Close();
                        MessageBox.Show("Codice Aggiornato!");
                        reader.Close();
                      //  reader3.Close();
                        conn.Close();
                        conn2.Close();
                        conn3.Close();
                        Response.Redirect("Default.aspx");
                    }
                }
                else Response.Redirect("Default.aspx");
            }
            else Response.Redirect("Default.aspx");
        }
