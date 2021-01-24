cs
var panel = new Panel
{
	Size = new Size(500, 500),
	BackColor = Color.Red
};
panel.Controls.Add(new TextBox { Text = "Value" });
panel.Controls.Add(new TextBox { Text = "Value2" });
if (panel.Controls.OfType<TextBox>().All(x => !string.IsNullOrEmpty(x.Text)))
{
	//Do something
}
The code in the if statement will only execute if all the Text properties of TextBoxes are not empty.
