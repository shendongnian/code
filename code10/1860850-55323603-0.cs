     public partial class Form1 : Form
        {
           
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Task.Factory.StartNew(() =>
                {
                    Action act1 = (() =>
                    {
                        Form2 form2 = new Form2();
                        form2.StartPosition = FormStartPosition.CenterParent;
                        form2.Show();
                    });
                    this.BeginInvoke(act1);
                });
            }
    }
