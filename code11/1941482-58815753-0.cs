    // Warning - The code below is WRONG! Awful even, since it will _appear_ to work in some cases.
    void Main()
    {
    	Application.Run(new Form1());
    }
    
    public class Form1 : Form
    {
    	Process process1 = new Process();
    	Button button1;
    	RichTextBox richTextBox1;
    
        public Form1()
        {
            button1 = new Button { Text = "Run" };
    		button1.Click += button1_Click;
    		Controls.Add(button1);
    		
    		richTextBox1 = new RichTextBox { Left = 100 };
    		Controls.Add(richTextBox1);
    
            process1.StartInfo.RedirectStandardError = true;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.FileName = "cmd.exe";
            process1.StartInfo.Arguments = "/?";
        }
    
        public void button1_Click(object sender, EventArgs e)
        {
    		test();
        }
    
        public void test()
        {
            process1.Start();
    
    		process1.OutputDataReceived += process1_OutputDataReceived;
    		process1.ErrorDataReceived += process1_ErrorDataReceived;
    
            process1.BeginOutputReadLine();
            process1.BeginErrorReadLine();
    
            process1.WaitForExit();
            process1.CancelOutputRead();
            process1.CancelErrorRead();
            process1.Close();
        }
    
        private void process1_OutputDataReceived(object sender, 
                                                 System.Diagnostics.DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data)) return;
    
            richTextBox1.Text += e.Data + "\n";
        }
    
        private void process1_ErrorDataReceived(object sender, 
                                                System.Diagnostics.DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data)) return;
    
            richTextBox1.Text += e.Data + "\n";
        }
    }
