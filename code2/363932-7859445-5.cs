    class Order 
    {
        public void PrepareShipping()
        {
            foreach (Item item in m_items)
                item.PrepareShiping();
        }
    
        public void PerformShipping()
        {
            foreach (Item item in m_items)
                item.PerformShipping();
        }
    
        // and for those who don't need asynchronity
        public void Ship()
        {
            PrepareShipping();
            PerformShipping();
        }
    }
