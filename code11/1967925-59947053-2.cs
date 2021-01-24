     public partial class Form1 : Form
            {
                List<Control> CustomControls = new List<Control>();
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    if(CustomControls.Count == 0){
                    Form2 frm2 = new Form2();
                    frm2.FormClosed += Frm2_FormClosed;
        
                    CustomControls.Add(frm2);
                    frm2.Show();
                }
                else {
                  ((Form2)CustomControls[0]).Show();
                 }
                    
                }
        
                private void Frm2_FormClosed(object sender, FormClosedEventArgs e)
                {
                    MessageBox.Show(((Form2)this.CustomControls[0]).PubId);
                }
            }
    
    Form 2 :
    
        public partial class Form2 : Form
            {
                public string PubId { get; set; }
        
                public Form2()
                {
                    InitializeComponent();
                }
                
                private void button1_Click(object sender, EventArgs e)
                {
                    PubId = "8";
                }
            }
