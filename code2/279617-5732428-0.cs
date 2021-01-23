    class House
    {
        public Room Bedroom { get; set; }
    }
    
    class HouseService
    {
        public ValidateHouse(House aHouse)  //There is no guarantee that this method is ever called
        {
            if (aHouse.Bedroom == null)
            {
                throw new InvalidFieldException();
            }
        }
    }
