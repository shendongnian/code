    // tested in VS 2010 Pro, .NET 4.0 FrameWork Client Profile
    // uses:
    // CheckBox named 'checkBox1
    // ContextMenuStrip named 'contextMenuStrip1
    // TextBox named 'cMenuSelectionInfo for run-time checking of results
        // used to position the ContextMenuStrip    
        private Point cPoint;
        // context click ? dubious assumption that 'right' = context click
        private bool cmOpenedRight;
        // the clicked ToolStripMenuItem
        private ToolStripMenuItem tsMIClicked;
        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cmOpenedRight = e.Button == MouseButtons.Right;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // positioning the CheckBox like this
            // is something in a 'real-world' example
            // you'd want to do in the Form.Load event !
            // unless, of course, you'd made the CheckBox movable
            if(checkBox1.Checked)
            {
                contextMenuStrip1.Show();
                cPoint = PointToScreen(new Point(checkBox1.Left, checkBox1.Top + checkBox1.Height));
                contextMenuStrip1.Location = cPoint;
            }
            else
            {
                contextMenuStrip1.Hide();
            }
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // assume you do not have to check for null here ?
            tsMIClicked = e.ClickedItem as ToolStripMenuItem;
            tbCbMenuSelectionInfo.Text = tsMIClicked + " : " + ! (tsMIClicked.Checked);
        }
        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = checkBox1.Checked;
        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (cmOpenedRight)
            {
                tbCbMenuSelectionInfo.Text += " : closed because : " + e.CloseReason.ToString();
            }
        }
