        class Task
        {
            public List<ElementControl> Elements = new List<ElementControl>();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            Task task = new Task();
            foreach (ElementControl ele in SequenceListBox.Items)
                task.Elements.Add(ele);
            progressBar1.Maximum = task.Elements.Count;
            backgroundWorker1.RunWorkerAsync(task);
        }
        public delegate void ReportProgressHandler(int value, string text);
        private void ReportProgress(int value, string text)
        {
            if (InvokeRequired)
                Invoke(new ReportProgressHandler(ReportProgress), value, text);
            else
            {
                if(value <= progressBar1.Maximum)
                    progressBar1.Value = value;
                label1.Text = text;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Task task = e.Argument as Task;
            if (task != null)
            {
                int i = 0;
                foreach (ElementControl ele in task.Elements)
                {
                    i++;
                    ele.RunElement();
                    ReportProgress(i, "sometext + " + i.ToString());
                    System.Threading.Thread.Sleep(1000);
                }
                MessageBox.Show("Completed!");
            }
        }
