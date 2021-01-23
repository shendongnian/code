    class Item
    {
        public void PrepareShiping()
        {
            m_queuedBoat.QueueForShipping(this);
        }
    
        public void PerformShipping()
        {
            m_queuedBoat.StartActualShippingIfNotAlreadyStarted();
            m_queuedBoat.WaitForShippingEnd();
            ProcessReceipt(m_queuedBoat.GetReceiptForItem(this));
        }
    }
