        [Test]
        public void TestPlanCheck()
        {
            var plan1 = new Plan { Start = 1, End = 2 };
            var plan2 = new Plan { Start = 2, End = 3 };
            var plan3 = new Plan { Start = 3, End = 4 };
            var planInfos = new List<PlanInfo>
            {
                 new PlanInfo{ Name = "Test1", Plans = new []{ plan1, plan2}.ToList() },
                 new PlanInfo{Name = "Test2", Plans = new []{plan2, plan3}.ToList()},
                 new PlanInfo{Name = "Test3", Plans = new []{ plan3, plan2}.ToList() }
            };
            var totalPlanInfos = planInfos.Count();
            var commonPlans = planInfos
                .SelectMany(x => x.Plans
                    .Select(p => new { x.Name, Plan = p }))
                .GroupBy(x => x.Plan)
                .Where(x => x.Count() == totalPlanInfos)
                .Select(x => x.Key)
                .ToList();
        }
        private class Plan
        {
            public int Start { get; set; }
            public int End { get; set; }
        }
        private class PlanInfo
        {
            public string Name { get; set; }
            public List<Plan> Plans { get; set; }
        }
