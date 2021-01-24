    public static class Utility
    {
        private static readonly Random random = new Random();
        // Returns true or false, with a user defined chance of 'True'
        // E.g. chanceForTrue = 30 means a 30% chance of 'True'
        public static bool GetRandomBool(int chanceForTrue)
        {
            return random.Next(101) < chanceForTrue;
        }
    }
    public class Room 
    {
        // If true, there is a monster in the room
        private readonly bool hasMonster;
        // Constructor
        public Room()
        {
            // 50% chance of having a monster
            hasMonster = Utility.GetRandomBool(50);
        }
        // ...rest of the class
    }
