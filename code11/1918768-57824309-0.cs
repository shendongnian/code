    private void Izrada_kartice_KeyDown(object 
    sender,KeyEventArgs e)
    {
    if(e.KeyCode == Keys.ControlKey)
    {
        promijeni_veličinu_naslov = true;
        this.BackColor = Color.Red;
    }
    }
    private void Izrada_kartice_KeyUp(object sender, 
    KeyEventArgs e)
    {
        if(e.KeyCode == Keys.ControlKey)
    {
        promijeni_veličinu_naslov = false;
        this.BackColor = Color.Green;
    }
    }
