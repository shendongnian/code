public partial class Form1 : Form
{
	public string changeTextBoxValue { set { textBox1.Text = value; } }
	public Form1()
	{
		InitializeComponent();
	}
	private void btnCreateCopiedWindow_Click(object sender, EventArgs e)
	{
		Form1 secondForm = new Form1();
		secondForm.changeTextBoxValue = "Different value for second form";
		secondForm.Show();
	}
}
Instead of using a TextBox you would have your picturebox and would change the image using the property, but the idea is the same. You instantiate the same form and change the values you need and then show it to the user.
Hope this helps!
