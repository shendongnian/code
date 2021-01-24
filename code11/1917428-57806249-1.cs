    private void PushBarcodeListener(IBarcodeListener l)
    {
       m_listeners.Push(l);
       if (m_listeners.Count == 1)
       {
          // as soon as you have an interested party, add your one and only 
          // event handler to the SDK object and enable it (the exact details
          // of this are SDK dependent).
       }
    }
    private void PopBarcodeListener(IBarcodeListener l)
    {
       if (!Object.ReferenceEquals(l, m_listeners.Peek())
          Throw new Exception("Only the active BarcodeListener can be removed");
    
       m_listeners.Pop();
       if (m_listeners.Count == 0)
       {
          // if no one is interested in barcodes, stop listening by disabling the SDK
          // object and removing the event handler
       }
    }
