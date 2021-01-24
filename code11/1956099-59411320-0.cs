	public class Dice
    {
        private int LastRolled;
		private static Random R = new Random();
        public Dice()
        {
            RollTheDice();
        }
        public Dice(int fakeRoll)
        {
            LastRolled = fakeRoll;
        }
        public int RollTheDice()
        {
            LastRolled = R.Next(6) + 1;
            return LastRolled;
        }
        public int GetLastRolled()
        {
            return LastRolled;
        }
    }
