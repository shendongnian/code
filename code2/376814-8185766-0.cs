[c#]
private void Form1_Load(object sender, System.EventArgs e)
{
    SizeLastColumn(lvSample);
}
private void listView1_Resize(object sender, System.EventArgs e)
{
    SizeLastColumn((ListView) sender);
}
private void SizeLastColumn(ListView lv)
{
    lv.Columns[lv.Columns.Count - 1].Width = -2;
}
