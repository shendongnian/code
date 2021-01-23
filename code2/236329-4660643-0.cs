    int i = 0;
    foreach (string gig in giggles.Where( x => i <= 4))
    {
        lblDo.Text = gig;
        i++;
    }
