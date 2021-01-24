 CSharp
private void Constructor(object sender, EventArgs e)
{
    ProcessListBox.Items.AddRange(
                Process.GetProcesses()
                    .Select(process => process.ProcessName)
                    .ToArray());
}
You may receive a warning about casting `string[]` to `object[]` on runtime.<br/>
You can fix it by adding redundant explicit cast:
 CSharp
private void Constructor(object sender, EventArgs e)
{
    ProcessListBox.Items.AddRange(
                (string[]) Process.GetProcesses()
                    .Select(process => process.ProcessName)
                    .ToArray());
}
