    private void txtAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            int licznik = 1;
            if (e.KeyChar == (char)13)
            {
                string adres = txtAdres.Text;
                webBrowser1.Navigate(adres);
                licznik = 0;
            }
            if (licznik == 0)
            {
                webBrowser1.Focus();
            }
        }
