    class Order 
    {
        public void BeginShipping()
        {
            foreach (Item item in m_items)
                item.BeginShipping();
        }
    
        public void EndShipping()
        {
            foreach (Item item in m_items)
                item.EndShipping();
        }
    
        // end for those who don't need asynchronity
        public void Ship()
        {
            BeginShipping();
            EndShipping();
        }
    }
