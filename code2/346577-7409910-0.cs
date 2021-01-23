    void UpdateLabelInLoop()
    {
        for( int i = 0; i < 1000; ++i )
        {
            someLabel.Text = i.ToString();
            someLabel.Invalidate();
    
            // allow some time between each update,
            // for demonstration purposes only.
            System.Threading.Thread.Sleep(15);
        }
    }
