    private void button1_Click(object sender, EventArgs e)
    {
        double result = 0;
        double nextNumber = 0;
        foreach (DataGridViewCell  cell in dataGridView1.SelectedCells)
        {
            if (double.TryParse(cell.Value.ToString(), out result)) 
            {
                nextNumber += result;
                label2.Text = nextNumber.ToString();
            }
        }
    }
