    SqlCommand cmd = new SqlCommand(@"SELECT Code, GenericName FROM tbl_Item", Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chklItems.DataSource = null; // chklItems is a CheckedListBox
            if (chklItems.Items.Count > 0)
                chklItems.Items.Clear();
            chklItems.DataSource = dt;
            chklItems.DisplayMember = "GenericName";
            chklItems.ValueMember = "Code";
