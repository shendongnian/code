    public void OnHit()
    {
        EventHandler handler = BallInPlay;
        if (handler != null)
        {
            handler(this, new EventArgs());
        }
        else
        {
            MessageBox.Show("null!");
        }
    }
