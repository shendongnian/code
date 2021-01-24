        private void SafeLog(string value)
        {
            if (this.InvokeRequired)
            {
                // if we are being called between threads, we have to ask the original UI thread to perfom the task
                this.Invoke(new StringVoidInvoker(SafeLog), new object[] { value });
            }
            else
            {
                this.listBox1.Items.Add(value);
            }
        }
