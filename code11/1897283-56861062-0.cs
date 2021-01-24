c#
public Form1()
{
    if (x == 1 && this.ListBox1.SelectedIndex != 5 && this.ListBox1.SelectedIndex != -1)
    {
       ListBox1.MouseDoubleClick += new MouseControlHandler(ListBox1_MouseDoubleClick);
    else 
    {
        ListBox1.MouseDoubleClick = null;
    }              
}
private void ListBox1_MouseDoubleClick(object sender, System.EventArgs e)
{
    int index = this.ListBox1.IndexFromPoint(e.Location);
    if (index != System.Windows.Forms.ListBox.NoMatches)
    {
        MessageBox.Show("Hello World!");
    }
}
