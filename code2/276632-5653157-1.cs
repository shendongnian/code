cs
public Form1()
{
    InitializeComponent();
    DataGridViewComboBoxColumn cmbcolumn = new DataGridViewComboBoxColumn();
    cmbcolumn.Name = "cmbColumn";
    cmbcolumn.HeaderText = "combobox column";
    cmbcolumn.Items.AddRange(new string[] { "aa", "ac", "aacc" });
    dataGridView1.Columns.Add(cmbcolumn);
    dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
}
private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
{
    ComboBox combo = e.Control as ComboBox;
    if (combo != null)
    {
        combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
    }
}
private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
{
    ComboBox cb = (ComboBox)sender;
    string item = cb.Text;
    if (item != null)
        MessageBox.Show(item);
}
