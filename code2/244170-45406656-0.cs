    DataGridViewTextBoxColumn comments = new DataGridViewTextBoxColumn();
    {
        comments.Name = "comments";
        comments.HeaderText = "Comments";
        comments.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        comments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        this.dataGridView1.Columns.Add(comments);
    }
