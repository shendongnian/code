    namespace runtime
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                int lettercount = 0;
                string strText = "Debugging";
                string letter;
               
    
                for (int i = 0; i < strText.Length; i++)
                {
                    letter = strText.Substring(i,1);
    
                    if (letter == "g")
                    {
                        lettercount++;
                    }
                    
                }
                textBox1.Text = "g appear " + lettercount + " times";
            }
        }
    }
