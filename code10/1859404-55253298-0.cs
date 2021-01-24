    private void btnReadRandomNumbers_Click(object sender, EventArgs e){
    
    try
    {
        lstRandomNumbers.Items.Clear();
        if (fodOpenFile.ShowDialog() == DialogResult.OK)
        {
                var linesOfFile = File.ReadAllLines( fodOpenFile.FileName ).Select( int.Parse ).ToList();
                lblSumNumbers.Text = linesOfFile.Sum().ToString();
                lblNumberCount.Text = linesOfFile.Count().ToString();
                lstRandomNumbers.DataSource = linesOfFile;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("There is a problem with the disk file." + Environment.NewLine + ex.Message, "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
