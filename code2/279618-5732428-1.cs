    class House
    {
        private Room theBedroom;
        public Room Bedroom 
        { 
            get
            {
                return theBedroom;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                theBedroom = value;
            }
        }
    }
