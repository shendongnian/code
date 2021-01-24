    private void button1_Click(object sender, EventArgs e)
        {
            string text = "hello world";
            label1.Text = String.Empty;
            //creating a new thread to not freeze a main ui thread
            Thread thread = new Thread(()=> SlowDisplayText(text));
            //starting a thread
            thread.Start();
        }
        private void SlowDisplayText(string text)
        {
            foreach (char character in text)
            {
                //invoking label, since it is on main thread
                label1.Invoke((MethodInvoker)delegate
                {
                    //adding single character at the time
                    label1.Text += character;
                });
                Thread.Sleep(100);
            }
        }
