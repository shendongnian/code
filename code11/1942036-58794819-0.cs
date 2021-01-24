     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public ArrayList listem = new ArrayList(5);
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(listem[0].ToString());
                Form2 form = new Form2();
                form.ShowDialog();
                
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                listem.Add(1);
                listem.Add(2);
                listem.Add(3);
                listem.Add(4);
                listem.Add(5);
            }
        }
