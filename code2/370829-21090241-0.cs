    private void ShowHidden_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.M) )
            {
                OldBisProdId.Visible = true;
                OldGanProdId.Visible = true;
            }
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.C))
            {
                OldBisProdId.Visible = false;
                OldGanProdId.Visible = false;
            }
        }
