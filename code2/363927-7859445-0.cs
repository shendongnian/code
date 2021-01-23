    class Item
    {
        public void BeginShiping()
        {
            m_queuedBoat.QueueForShipping(this);
        }
    
        public void EndShipping()
        {
            m_queuedBoat.StartActualShippingIfNotAlreadyStarted();
            m_queuedBoat.WaitForShippingEnd();
            ProcessReceipt(m_queuedBoat.GetReceiptForItem(this));
        }
    }
