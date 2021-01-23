        const string Separator= "---Command Completed--\xE3\xE2\xE1\xE0\xE3";   
        // Has to be something that won't occur in normal output.  
        volatile bool finished = false;
        private void button1_Click(object sender, EventArgs e)
        {         
            foreach (string command in _commands)
                Run(command);
        }
        private void writeToConsole(string output)
        {
            if (output.IndexOf(Separator) >= 0)
                finished = true;
            else
                richTextBox1.AppendText(output);
        }
        private void Run(string command)
        {
            finished = false;
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.WriteLine("@echo " + Seperator);
            while (!finished)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            finished = true;
        }
