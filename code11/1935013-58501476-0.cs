    private void PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (dgv_search.Visible == true)
                    {
                        dgv_search.Focus();
                    }
                }
            }
            catch { }
        }
