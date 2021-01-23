    ...
    
    namespace comregister
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            string framework = Environment.GetEnvironmentVariable("SystemRoot") + @"\Microsoft.NET\Framework\v2.0.50727\";
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                FileInfo fi = new FileInfo(textBox1.Text);
                string fn = fi.FullName.Substring(0, fi.FullName.Length - 4);
                string dll = "\"" + fi.FullName + "\"";
                string tlb = "\"" + fn + ".tlb\"";
                
                Process p = new Process();
                p.StartInfo.FileName = framework + "regasm.exe";
                p.StartInfo.Arguments = dll + " /tlb:" + tlb + " /codebase";
                p.Start();
                p.WaitForExit();
                label2.Text = "registered";
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                FileInfo fi = new FileInfo(textBox1.Text);
                string dll = "\"" + fi.FullName + "\"";
    
                Process p = new Process();
                p.StartInfo.FileName = framework + "regasm.exe";
                p.StartInfo.Arguments = dll + " /unregister";
                p.Start();
                p.WaitForExit();
                label2.Text = "unregistered";
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        }
    }
