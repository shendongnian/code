 C#
private void Bstart_Click(object sender, EventArgs e)
{
    timer1.Start();
    lvi1 = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
    listView2.Items.Add(lvi1);
    
    // Add an empty SubItem or any placeholder here:
    // lvi1.SubItems.Add(string.Empty);
    lvi1.SubItems.Add("-");
}
Also like I already mentioned in a comment, your `if(k > 1)` and `else if (k == 1)` have exactly the same content. You can merge those:
C#
if (k >= 1)
{
    label1.Text = k.ToString() + " seconds remaining";
}
else
{
    timer1.Stop();
    // ...
