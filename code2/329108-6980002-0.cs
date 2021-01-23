        public double Width
        {
            set { Contract.Ensures(Height == Contract.OldValue(Height)); }
        }
    
        public double Height
        {
            set { Contract.Ensures(Width == Contract.OldValue(Width)); }
        }
