    private void Remove_Click(object sender, EventArgs e)
        {
           price = Convert.ToDecimal(Price.Text);
           price -= Convert.ToDecimal(dgvSelected.SelectedCells[3].Value.ToString());
           Price.Text = price.ToString();         
           dgvSelected.Rows.Remove(dgvSelected.CurrentRow);
        }
