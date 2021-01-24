   public class Person
   {
      public Person(string name, int position)
      {
         Name = name;
         Position = position;
      }
      public string Name { get; set; }
      public int Position { get; set; }
   }
      static void Main(string[] args)
      {
         var winners = new Person[]
         {
            new Person("Test 1", 1),
            new Person("Test 2", 1),
            new Person("Test 3", 1),
            new Person("Test 4", 1),
            new Person("Test 5", 5),
            new Person("Test 6", 6),
            new Person("Test 7", 7),
            new Person("Test 8", 8),
            new Person("Test 9", 9),
            new Person("Test 10", 9),
            new Person("Test 11", 11),
            new Person("Test 12", 11),
            new Person("Test 13", 13),
            new Person("Test 14", 14),
            new Person("Test 15", 15),
            new Person("Test 16", 16),
            new Person("Test 17", 17),
            new Person("Test 18", 18),
            new Person("Test 19", 19),
            new Person("Test 20", 19)
         };
         var prizes = SplitPrizeFund(1000, winners.Length);
         AllocatePrizes(winners, prizes);
      }
      private static void AllocatePrizes(IEnumerable<Person> positions, double[] prizes)
      {
         var orderedPositions = positions.OrderBy(f => f.Position).ToArray();
         for (var pos = 0; pos < orderedPositions.Length;)
         {
            var currentPerson = orderedPositions[pos];
            // Find equally placed people (if any)
            var comList = orderedPositions.Skip(pos).Where(f => f.Position == currentPerson.Position).ToList();
            // We should now have one or more people in our list
            var splitWays = comList.Count;
            // Total the prize fund over the places found
            double splitFund = prizes.Skip(pos).Take(splitWays).Sum();
            // Allocate the total winnings equally between winners of this place
            bool first = true;
            foreach (var person in comList)
            {
               if (first)
               {
                  Console.WriteLine($"{person.Name,-20} {(splitFund / splitWays),10:C2}");
                  first = false;
               }
               else
               {
                  // Identify equal placed winners 
                  Console.WriteLine($"{person.Name,-19}= {(splitFund / splitWays),10:C2}");
               }
            }
            pos += splitWays;
         }
      }
      private static double[] SplitPrizeFund(double totalFund, int numberOfPrizes)
      {
         var prizes = new double[numberOfPrizes];
         var remainingFund = totalFund;
         int remainingPrizes = numberOfPrizes;
         // Special handling for top three places
         int pos = 0;
         prizes[pos] = Math.Round(remainingFund * 0.25, 2, MidpointRounding.AwayFromZero);
         pos += 1;
         prizes[pos] = Math.Round(remainingFund * 0.20, 2, MidpointRounding.AwayFromZero);
         pos += 1;
         prizes[pos] = Math.Round(remainingFund * 0.15, 2, MidpointRounding.AwayFromZero);
         pos += 1;
         remainingPrizes -= 3;
         remainingFund -= prizes[0] + prizes[1] + prizes[2];
         // Linear reducing split from 4th (replace this with whatever you want)
         int totalPortions = 0;
         for (int i = 1; i <= remainingPrizes; i++)
            totalPortions += i;
         for (int i = remainingPrizes; i >= 1; i--)
         {
            prizes[pos] = Math.Round(remainingFund * i / totalPortions, 2, MidpointRounding.AwayFromZero);
            remainingFund -= prizes[pos];
            totalPortions -= i;
            pos++;
         }
         return prizes;
      }
