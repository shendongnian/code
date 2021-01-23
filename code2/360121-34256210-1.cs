        [DllImport("user32.dll")]
            static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);    
            
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    
                    Process p = Process.Start(textBox1.Text);
                    p.WaitForInputIdle();
                    SetParent(p.MainWindowHandle, panel1.Handle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    }
