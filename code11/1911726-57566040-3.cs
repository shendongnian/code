    private void tabControl1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            tabControl1.DoDragDrop(tabControl1.SelectedTab, DragDropEffects.All);
        }
    }
    private void tabControl1_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(TabPage)))
            e.Effect = DragDropEffects.Move;
    }
    private void tabControl1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
    {
        if (e.Action == DragAction.Drop)
        {
            var tabPage = tabControl1.SelectedTab;
            if (!tabControl1.RectangleToScreen(tabControl1.Bounds).Contains(Cursor.Position))
            {
                var form = new Form();
                form.Text = tabPage.Text;
                var tabControl = new TabControl();
                tabControl.TabPages.Add(tabPage);
                tabControl.Dock = DockStyle.Fill;
                form.Controls.Add(tabControl);
                form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(Cursor.Position.X - form.Width / 2,
                    Cursor.Position.Y - SystemInformation.CaptionHeight / 2);
                form.Show();
                e.Action = DragAction.Cancel;
                //You can comment tabControl.TabPages.Add 
                //Then set e.Action = DragAction.Continue
                //Then the DragDrop event will raise and add the tab there.
            }
        }
    }
    private void tabControl1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(TabPage)))
        {
            var tabPage = (TabPage)e.Data.GetData(typeof(TabPage));
            tabControl1.TabPages.Remove(tabPage);
            tabControl1.TabPages.Add(tabPage);
        }
    }
