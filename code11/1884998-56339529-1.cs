    class People
    {
        public int ID { get; set; }
        public int Rank { get; set; }
        public float? Prize { get; set; }
    }
         private void CheckPrices()
        {
            float prize = 1000;
            Random rnd = new Random(1);
            var peopleList = new List<People>();
            for (int i = 0; i < 20; i++)
            {
                peopleList.Add(new Test.People() { ID = i + 1, Rank = rnd.Next(5, 100) });
            }
            var firstPrize = prize * 25 / 100;
            var secondPrize = prize * 20 / 100;
            var thirstPrize = prize * 15 / 100;
            int i = 0;
            //Sets first places prizes.
            foreach (var person in peopleList.OrderByDescending(ro => ro.Rank))
            {
                i++;
                if (i == 1)
                    person.Prize = firstPrize;
                else if (i == 2)
                    person.Prize = secondPrize;
                else if (i == 3)
                    person.Prize = thirstPrize;
                else
                    break;
            }
            
            var totalRank = peopleList.Sum(ro => ro.Rank);
            float prizePerRank = (prize - (firstPrize + secondPrize + thirstPrize)) / totalRank;
            foreach (var person in peopleList.Where( ro=> ro.Prize == null))
            {
                person.Prize = person.Rank * prizePerRank;
            }
            //
            var totalPrizeDistributed = peopleList.Sum(ro => ro.Prize); //= 1000
        }
    }
