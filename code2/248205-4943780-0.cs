        public void countToLots()
        {
            for (int i = 0; i < 10000000; i++)
            {
                SetText("Counting to 10000000, value is " + i + Environment.NewLine);
            }
        }
        public void SetText(string text)
        {
            
            if (this.textBox1.InvokeRequired())
            {
                Action<string> auxDelegate = SetText;
                this.BeginInvoke(auxDelegate,text);
            }
            else
            {
                this.textBox1.Text = text;
            }
        }
