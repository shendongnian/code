        private void dgViewData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dgViewData.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.ColumnHeader)
                {
                    foreach (ToolStripMenuItem menuItem in conMicImport.Items)
                    {
                        menuItem.Visible = menuItem.Text.ToString().Contains("Add") == true ? false : true;
                    }
                    conMicImport.Show(dgViewData, e.Location);
                    ctxtDG = dgViewData;
                }
            }
        }
