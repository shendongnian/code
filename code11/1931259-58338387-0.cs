    private void txtPuntosTotalesAGenerar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            int finalSamplePoints = Convert.ToInt32(txtPuntosTotalesAGenerar.Text);
            int try1 = 1500;
            if (finalSamplePoints > try1)
            {
                txtPuntosTotalesAGenerar.BackColor = Color.Orange;
            }
            else if (finalSamplePoints < try1)
            {
                txtPuntosTotalesAGenerar.BackColor = Color.Red;
            }
            else if (finalSamplePoints == try1)
            {
                txtPuntosTotalesAGenerar.BackColor = Color.Green;
            }
        }
    }
