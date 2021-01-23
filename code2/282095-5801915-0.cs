        private void timer1_Tick(object sender, EventArgs e)
        {
            content = webBrowser1.Document.GetElementById("speed");
            string x = content.OuterHtml;
            if (x != CheckString)
            {
                timer1.Enabled = false;
                MessageBox.Show(x);
            }
        }
