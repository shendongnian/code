    class DinnerParty
    {
        private int NumberOfPeople;
    
             ....
    
        public DinnerParty SetPartyOptions(int people, bool fancy) {
            NumberOfPeople = people;
            .....
    
            return this; // Return own instance to allow for further accessing.
        }
    
        public int GetNumberOfPeople() {
            return NumberOfPeople;
        }
    }
