    string OSRAM = "";
    private void TxtPa_KeyDown(object sender, KeyEventArgs e)
    {            
        if (e.Key == Key.Tab)
        {
           OSRAM = OSRAM + " " + txtPa.Text;
                serl[5] = OSRAM;              
                e.Handled = true;
        }
     }
