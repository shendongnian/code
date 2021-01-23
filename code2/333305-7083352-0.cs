        public void Test()
        {
            Objective math = Init();
            RankObjective("", math);
            System.Console.ReadLine();
        }
        private void RankObjective(string rank, Objective objective)
        {
            int count = 1;
            if (!String.IsNullOrEmpty(rank))
                Console.WriteLine(objective.Name + ": " + rank);
            foreach (Objective child in objective.Objectives)
            {
                string newRank = String.IsNullOrEmpty(rank) ? count.ToString() : rank + "." + count.ToString();
                RankObjective(newRank, child);
                count++;
            }
        }
        private Objective Init()
        {
            Objective math = new Objective("Math");
            Objective geometry = new Objective("Geometry");
            geometry.Objectives.Add(new Objective("Squares"));
            geometry.Objectives.Add(new Objective("Circles"));
            Objective triangle = new Objective("Triangle");
            triangle.Objectives.Add(new Objective("Types"));
            geometry.Objectives.Add(triangle);
            math.Objectives.Add(geometry);
            math.Objectives.Add(new Objective("Algebra"));
            math.Objectives.Add(new Objective("Trigonometry"));
            return math;
        }
