      enum RollScoreType
      {
         HighDie,
         Pair,
         TwoPair,
         ThreeOfAKind,
         FullHouse,
         SmallStright,
         LargeStraight,
         FourOfAKind,
         FiveOfAKind
      }
      struct RollScore
      {
         public RollScoreType type;
         public byte highestDie;
         public byte nextHighestDie;
         public RollScore(RollScoreType type, byte highest, byte next)
         {
            this.type = type;
            this.highestDie = highest;
            this.nextHighestDie = next;
         }
         public override string ToString()
         {
            return string.Format("{0} {1} {2}", type, highestDie, nextHighestDie);
         }
      }
      static RollScore GetDiceScore(string input)
      {
         char[] dice = input.ToCharArray();
         byte[] diceCount = new byte[6];
         for (int i = 0; i < dice.Length; i++)
            diceCount[int.Parse(dice[i].ToString())-1]++;
         if (Array.IndexOf(diceCount, (byte)5) >= 0)
            return new RollScore(RollScoreType.FiveOfAKind, (byte)(Array.IndexOf(diceCount, (byte)5) + 1), 0);
         else if (Array.IndexOf(diceCount, (byte)4) >= 0)
            return new RollScore(RollScoreType.FourOfAKind, (byte)(Array.IndexOf(diceCount, (byte)4) + 1), (byte)(Array.IndexOf(diceCount, (byte)1) + 1));
         else if (Array.IndexOf(diceCount, (byte)3) >= 0)
         {
            byte three = (byte)(Array.IndexOf(diceCount, (byte)3) + 1);
            if (Array.IndexOf(diceCount, (byte)2) >= 0)
            {
               byte pair = (byte)(Array.IndexOf(diceCount, (byte)2) + 1);
               return new RollScore(RollScoreType.FullHouse, Math.Max(pair, three), Math.Min(pair, three));
            }
            else
               return new RollScore(RollScoreType.ThreeOfAKind, three, (byte)(Array.LastIndexOf(diceCount, (byte)1) + 1));
         }
         else if (Array.IndexOf(diceCount, (byte)2) >= 0)
         {
            byte pair = (byte)(Array.IndexOf(diceCount, (byte)2) + 1);
            byte highPair = (byte)(Array.LastIndexOf(diceCount, (byte)2) + 1);
            if (highPair != pair)
               return new RollScore(RollScoreType.TwoPair, highPair, pair);
            else
               return new RollScore(RollScoreType.Pair, pair, (byte)(Array.LastIndexOf(diceCount, (byte)1) + 1));
         }
         else
         {
            byte missingDie = (byte)Array.IndexOf(diceCount, (byte)0);
            switch(missingDie)
            {
               case 0:
                  return new RollScore(RollScoreType.LargeStraight, 6, 5);
               case 1:
                  return new RollScore(RollScoreType.SmallStright, 6, 5);
               case 4:
                  return new RollScore(RollScoreType.SmallStright, 4, 3);
               case 5:
                  return new RollScore(RollScoreType.LargeStraight, 5, 4);                  
               default:
                  return new RollScore(RollScoreType.HighDie, 6, (byte)(Array.LastIndexOf(diceCount, (byte)1, 3) + 1));
            }
         }
      }
