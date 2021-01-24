     private void CreateCol(string Col_Name)
        {
           if (DataGridView1.Columns.Contains (Col_Name)) return ;
            DataGridViewColumn Column1 = new DataGridViewTextBoxColumn
            {
                DataPropertyName = Col_Name,
                Name = Col_Name,
                HeaderText = Col_Name
            };
            DataGridView1.Columns.Add(Column1);
        
        }
