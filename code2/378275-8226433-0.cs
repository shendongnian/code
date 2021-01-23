      foreach (TabPage t in tabControl1.TabPages)
        {
            foreach (Control c in t.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is TextBox)
                        {
                            MessageBox.Show(cc.Name);
                        }
                    }
                }
            }
        }
