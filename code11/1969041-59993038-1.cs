 C#
var myButton = new System.Windows.Forms.Button()
{
    Name = "MyButton",
    Location = new System.Drawing.Point(100, 100),
};
myButton.Click += (sender, args) =>
{
    //Do something here.
};
var myTextBox = new System.Windows.Forms.TextBox()
{
    Name = "MyTextBox",
    Text = "Default text"
};
myTextBox.TextChanged += (sender, args) =>
{
    //Do something here.
};
this.Controls.AddRange(new Control[] { myButton, myTextBox });
