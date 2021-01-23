    private void button1_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("message", "caption", MessageBoxButtons.OK, 
        //                                    MessageBoxIcon.Asterisk,
        //                                    MessageBoxDefaultButton.Button1);
        MessageBoxCE(this.Handle, "message", "caption", 0);
    }
    // renamed to not collide with the Windows.Forms MessageBox class
    [DllImport("coredll", EntryPoint="MessageBox")]
    private static extern int MessageBoxCE(IntPtr hWnd, string lpText, 
                                           string lpCaption, int Type);
