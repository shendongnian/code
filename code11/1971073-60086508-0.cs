        static void Main(string[] args)
        {
            Player myPlayer = new Player();
            Tuple<int, int> newValues = SetAttributes(myPlayer.Health, myPlayer.Mana);
            myPlayer.Health = newValues.Item1;
            myPlayer.Mana = newValues.Item2;
            Console.WriteLine("In Main ...Health: " + myPlayer.Health + " Mana: " + myPlayer.Mana);
        }
