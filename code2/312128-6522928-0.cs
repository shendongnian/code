    private void button1_Click(object sender, EventArgs e)
        {
            using (Process sortProcess = new Process())
            {
                sortProcess.StartInfo.FileName = @"F:\echo_hello.bat";
                sortProcess.StartInfo.CreateNoWindow = true;
                sortProcess.StartInfo.UseShellExecute = false;
                sortProcess.StartInfo.RedirectStandardOutput = true;
                // Set event handler
                sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
                // Start the process.
                sortProcess.Start();
                // Start the asynchronous read
                sortProcess.BeginOutputReadLine();
                sortProcess.WaitForExit();
            }
        }
        void SortOutputHandler(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                richTextBox1.AppendText(e.Data ?? string.Empty);
            }));
        }
