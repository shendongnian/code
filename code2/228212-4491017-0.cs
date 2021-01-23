    using System;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                int count = 5;
                do{
                    MessageBox.Show(" Loop Executed ");
                    count++;
                }while (count <=4);
            }
    
    
            private void button2_Click(object sender, EventArgs e)
            {
                int count = 5;
                while (count <=4){
                    MessageBox.Show(" Loop Executed ");
                    count++;
                }
            }
        }
    }
