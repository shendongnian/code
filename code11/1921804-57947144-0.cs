        public void OnConnected(string str)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new TestEvent.clsConnect(OnConnected);
                textBox1.Invoke(d, new object[] { str });
            }
            else
            {
                textBox1.Text = str;
            }
        }
