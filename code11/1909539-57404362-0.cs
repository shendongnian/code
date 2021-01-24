    public partial class Form1 : Form
        {
            Form2 frm2;
            public Form1()
            {
                InitializeComponent();
                frm2 = new Form2();
            }
    
            private void ShowForm2(object sender, EventArgs e)
            {         
                frm2.Show();
            }
    
            private void Save(object sender, EventArgs e)
            {
                MessageBox.Show(frm2.TextFile);
            }
        }
