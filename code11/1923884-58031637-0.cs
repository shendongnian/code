    sqlCon = new SqlConnection(connectionString);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            
            SqlDataAdapter sqlDA = new SqlDataAdapter("[sp_selectTop10CycleTime]", sqlCon);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
           
            DataTable dataTbl = new DataTable();
            sqlDA.Fill(dataTbl);
            dgvNextCycleTime.DataSource = dataTbl;
            sqlCon.Close();
            //////////////////////////////// New code ////////////////////////////
            int ImagePathIndex = 0; // assuming that the image path  column is 0 (See in your case) 
            dgvNextCycleTime.Columns[ImagePathIndex].Visible = false; // Make visibility for the path = false
            DataGridViewImageColumn ImageColunm = new DataGridViewImageColumn();
            ImageColunm.HeaderText = "Image";
            ImageColunm.Name = "ImageName";
            ImageColunm.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ImageColunm.Image = null;
            dgvNextCycleTime.Columns.Add(ImageColunm); // Add the new colunm to the grid 
            
            // Add the image to the new column in the grid
            foreach (DataGridViewRow row in dgvNextCycleTime.Rows)
            {
                
                Image img = Image.FromFile(row.Cells[ImagePathIndex].Value.ToString());
                DataGridViewImageCell cell = row.Cells["ImageName"] as DataGridViewImageCell;
                cell.Value = img;
            }
