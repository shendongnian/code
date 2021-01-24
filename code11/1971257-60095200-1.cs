C#
public partial class Form1 : Form
{
    List<string> colors = new List<string> { "red", "blue", "green", "yellow" };
    public Form1()
    {
        InitializeComponent();
        // binding here
        this.panel1.DataBindings.Add("BackColor", this.comboBox1, "BackColor");
        this.panel2.DataBindings.Add("BackColor", this.comboBox2, "BackColor");
        this.panel3.DataBindings.Add("BackColor", this.comboBox3, "BackColor");
        this.panel4.DataBindings.Add("BackColor", this.comboBox4, "BackColor");
    }
    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBox = sender as ComboBox;
        if(comboBox.SelectedIndex < 0)
            return;
        comboBox.BackColor = Color.FromName(colors[comboBox.SelectedIndex]);
    }
}
