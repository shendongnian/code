    public float Price
    {
        get
        {
            if (this.bPrice > 30)
            {
                return this.bPrice - (this.bPrice * 0.10f);
            } 
            else
            {
                return this.bPrice;
            }
        }
        private set
        {
            this.bPrice = value
        }
    }
        
