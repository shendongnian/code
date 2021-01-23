    void DispatchEvent(MulticastDelegate handler, object sender, EventArgs args) 
    {
        if (handler != null)
        {
            // ...
            ((dynamic)handler)(sender, args);
        }
    }
