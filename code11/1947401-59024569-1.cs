c#
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private void scoreboard2pToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (Form2 f2 = new Form2())
        {
            if(f2.ShowDialog() == DialogResult.OK)
            {
                TabControl1.TabPages.Add(f2.SelectedText);
                //or insert
                //TabControl1.TabPages.Insert(0, f2.SelectedText);
            }
        }
    }
}
The second form:
c#
public partial class Form2 : Form
{
    //A read only property to return the text entered in the text box.
    public string SelectedText => txtBox2v2.Text;
    public Form2()
    {
        InitializeComponent();
    }
    public void OK_Click(object sender, EventArgs e)
    {
        //You only need to do this in your OK button.
        DialogResult = DialogResult.OK;
    }
}
Let each form deals with its own contents.
