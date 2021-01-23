    void ShowTaskbarIcon(bool e)
        {
            try
            {
                mf.Controls.Remove(mf.pnlMain);
                mf.ShowInTaskbar = e;
                mf.Controls.Add(mf.pnlMain);
            }
            catch (Exception ex)
            {
                ec.Get(ex.ToString(), 55, 1);
            }
        }
