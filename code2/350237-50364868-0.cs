    private void mh_MouseDownEvent(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    richTextBox1.AppendText("Left Button Press\n");
                }
                if (e.Button == MouseButtons.Right)
                {
                    richTextBox1.AppendText("Right Button Press\n");
                }
            }
            
            private void mh_MouseUpEvent(object sender, MouseEventArgs e)
            {
                 
                if (e.Button == MouseButtons.Left)
                {
                    richTextBox1.AppendText("Left Button Release\n");
                }
                if (e.Button == MouseButtons.Right)
                {
                    richTextBox1.AppendText("Right Button Release\n");
                }
        
            }
            private void mh_MouseClickEvent(object sender, MouseEventArgs e)
            {
                //MessageBox.Show(e.X + "-" + e.Y);
                if (e.Button == MouseButtons.Left)
                {
                    string sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    label1.Text = sText;
                }
            }
