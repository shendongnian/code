<b>ToolTip tt = null;</b>
private void button1_Click(object sender, EventArgs e)
{
    Label lblTest = new Label();
    lblTest.Text = "Test";
    <b>tt = new ToolTip();</b>
    this.Controls.Add(lblTest);
    <b>lblTest.MouseHover += new EventHandler(label_Hover);</b>
    lblTest.Location = new Point(10, 10);
}
<b>private void label_Hover(object sender, EventArgs e)
{
    tt.Show((Label)sender, "Tooltip");
}</b>
