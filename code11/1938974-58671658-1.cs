private void button1_Click(object sender, EventArgs e)
{
    Form2 frm = new Form2();
    frm.MyName = "Pass my name here";
    frm.Show();
}
public partial class Form2 : Form
{
    public string MyName { get; set }
    public Form2()
    {
        InitializeComponent();
    }
}
