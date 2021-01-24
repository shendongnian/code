public partial class Form1 : Form
{
    // Declare FNAME at class level so all methods can access it
    private string FNAME;
    private void button1_Click(object sender, EventArgs e)
    {
        // Assign a value to FNAME
        FNAME = GetTextNullIfEmpty(textBoxFname.Text);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        // Do something with FNAME here
    }
}
