    using System;
    using System.Collections.Generic;
    
    class Dices
    {
        public class Dice
        {
            private static Random roler = new Random();
            private int roledNumber;
            public int Role()
            {
                roledNumber = roler.Next(6) + 1 ;
                return roledNumber;
            }
    
            public int Number
            {
                get { return roledNumber; }
            }
        }
    
        static void Main(string[] args)
        {
            List<Dice> allDices = new List<Dice>();
    
            Dice firstDice = new Dice();
            allDices.Add(firstDice);
            
            if (firstDice.Role() == 6) createDices(allDices);
        }
    
        static void createDices(List<Dice> dices)
        {
            Dice first = new Dice();
            dices.Add(first);
            if (first.Role() == 6) createDices(dices);
            Dice second = new Dice();
            dices.Add(second);
            if (second.Role() == 6) createDices(dices);
            
        }
    }
