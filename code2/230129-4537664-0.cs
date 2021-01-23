        public void output(string str)
        {
            if (this.InvokeRequired)
            {
                var act = new Action<string>(output);
                this.Invoke(act, str);
            }
            else
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + DateTime.Now + @"  >>  " + str;
            }
        }
