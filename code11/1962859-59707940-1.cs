    public class Room 
    {
        // If true, there is a monster in the room
        private readonly bool hasMonster;
        // Constructor
        public Room()
        {
            var randomNumberGenerator = new Random();
            hasMonster = randomNumberGenerator.Next(2) > 0;
        }
        // ...rest of the class
    }
