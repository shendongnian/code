    protected virtual void OnLocationChanged(EventArgs args)
    {
       if(LocationChanged != null)
       {
         LocationChanged(this, args);
       }
    }
