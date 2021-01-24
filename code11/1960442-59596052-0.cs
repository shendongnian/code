csharp
foreach (string myitem in this.listBox1.Items)
{
  // myitem is only available in this scope
}
MessageBox.Show(myitem.toString(), "My Caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
System.Diagnostics.Process.Start(myitem.ToString());
You need to encapsulate everything you want in the foreach in a scope like so:
csharp
foreach (string myitem in this.listBox1.Items)
{
  MessageBox.Show(myitem.toString(), "My Caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
  System.Diagnostics.Process.Start(myitem.ToString());
}
