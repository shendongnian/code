    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {            
        if (dataGridView1.Columns[e.ColumnIndex].Name == "StatusImage")
        {
            // Your code would go here - below is just the code I used to test
            e.Value = Image.FromFile(@"C:\Pictures\TestImage.jpg");
        }
    }
