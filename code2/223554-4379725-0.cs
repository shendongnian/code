    protected virtual void OnValueChanged(object sender, EventArgs e)
    {
        var tmp = ValueChanged;
        if (tmp != null)
        {
           tmp(sender, e); // With the tmp, we won't explode if a subscriber changes the collection of delegates underneath us.
        }
    }
