csharp
this.Dispose();
`
<br>
<h2>Second Option</h2>
You can add a property to your form to track selected User Control.
**Form1:**
csharp
public Control SelectedItem { get; set; } = null;
private void DeleteButton_Click(object sender, EventArgs e)
{
    if (SelectedItem != null)
    {
        SelectedItem.Dispose();
    }
}
`
**UserControl1:**
csharp
// You can use any Event you prefer (Enter, Click or etc.).
private void GroupBox1_Enter(object sender, EventArgs e)
{
   // First Parent is FlowLayoutPanel
   // Second Parent is your Form
   Form1 parent = this.Parent.Parent as Form1;
   if (parent != null)
   {
      parent.SelectedItem = this;
   }
}
`
