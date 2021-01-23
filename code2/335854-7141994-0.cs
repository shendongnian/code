    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = "Select *  From ["+TABLE (THIS IS A STRING I GET FROM PREVIOUS FORM)+"]";
        using (conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=proyectos\" + Location(this is a string i get on the previous form) + ".mdb;User Id=admin;Password=;"))
        {
            conn.Open();
            //  Extraemos info de mi database y la meto en un datatable
            Adaptador = new OleDbDataAdapter(sql, conn);
            Builder = new OleDbCommandBuilder(Adaptador);
            Tabla = new DataTable();
            Adaptador.Fill(Tabla);
            // LLENO EL DATA GRID VIEW
            Bsource = new BindingSource();
            Bsource.DataSource = Tabla;
            dataGridView1.DataSource = Bsource;
            dataGridView1.Dock = DockStyle.Fill;
            // ** NOTE:
            // At this point, there's nothing to update - all that
            // has happened is that you've bound the DataTable
            // to the DataGridView.
            Adaptador.Update(Tabla);//if i put it here nothing happens
        
        } // Your connection will be closed at this point when the using
          // statement goes out of scope.
    }
