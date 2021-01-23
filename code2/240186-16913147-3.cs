    void DispatchEvent<T>(T handler, object sender, EventArgs args) 
    {
        if (handler != null)
        {
            // ...
            ((dynamic)handler)(sender, args);
        }
    }
