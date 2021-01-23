    private void createGraphicsColumn(Bitmap image)
    {
        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
        imageColumn .Image = image;
        imageColumn .Name = "Tree";
        imageColumn .HeaderText = "Nice tree";
        dataGridView1.Columns.Insert(2, imageColumn);
    }
