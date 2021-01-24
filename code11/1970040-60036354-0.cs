    ZeitenZeiger zeiten = new ZeitenZeiger();
    private void button2_Click(object sender, EventArgs e)
        {
            if (!online)
            {
                zeiten.Show();
                zeiten.ShowInTaskbar = false;
                online = true;
            }
            else
            {
                zeiten.Close();
                online = false;
            }
        } 
