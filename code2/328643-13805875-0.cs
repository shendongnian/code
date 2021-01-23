         if (dt.Rows.Count > 0)
        {
            dataGridViewProjects.DataSource = dt;
            dataGridViewProjects.Columns["Title"].Width = 300;
            dataGridViewProjects.Columns["ID"].Visible = false;
        }
