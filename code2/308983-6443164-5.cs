    private void ListView1Scrolled(object sender, System.EventArgs e)
    {
       SetScrollPos(GetScrollPos(ListView1.Handle), ListView2.Handle);
    }
    private void ListView2Scrolled(object sender, System.EventArgs e)
    {
       SetScrollPos(GetScrollPos(ListView2.Handle), ListView1.Handle);
    }
