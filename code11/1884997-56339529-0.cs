    class People
    {
        public int ID { get; set; }
        public int Rank { get; set; }
        public float Prize { get; set; }
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
                 
            var totalRank = peopleList.Sum(ro => ro.Rank);
            float prizePerRank = prize / totalRank;
            foreach (var person in peopleList)
            {
                person.Prize = person.Rank * prizePerRank;
            }
            //
            //var totalPrizeDistributed = peopleList.Sum(ro => ro.Prize); = 1000
        }
