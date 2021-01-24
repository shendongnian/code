    public partial class Form1 : Form
    {
    static public Label label2 = new Label();
    ...
    private void Form1_Load(object sender, EventArgs e)
    {
       Controls.Add(label2);
    }
    }
