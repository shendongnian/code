    public partial class Form2 : Form
    {
        ...
        private void button1_Click(object sender, EventArgs e)
        {
            Button myButton = new Button { Text = TbAccName.Text, Width=110, Height=80 };
            Form1.form1Panel.Controls.Add(myButton);
        }
    }
