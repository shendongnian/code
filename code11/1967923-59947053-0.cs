    public partial class Form1 : Form
        {
            List<Control> CustomControls = new List<Control>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                frm2.FormClosed += Frm2_FormClosed;
    
                CustomControls.Add(frm2);
    
                frm2.Show();
            }
    
            private void Frm2_FormClosed(object sender, FormClosedEventArgs e)
            {
                MessageBox.Show(((Form2)this.CustomControls[0]).PubId);
            }
        }
