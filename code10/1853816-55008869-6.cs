    private void button1_Click(object sender, EventArgs e)
    {
        double result = 0;
        foreach (DataGridViewCell  cell in dataGridView1.SelectedCells)
        {
            result = result + double.Parse(cell.Value.ToString());
        }
        label2.Text = result.ToString();
       
    }
