 var views = new List<ViewHistory>();
            views.Add(new ViewHistory {YYMMDD = "190530", Learn = 20, Practice = 1, Quiz = 30});
            views.Add(new ViewHistory { YYMMDD = "190531", Learn = 1, Practice = 1, Quiz = 30 });
            views.Add(new ViewHistory { YYMMDD = "190529", Learn = 2, Practice = 1, Quiz = 30 });
            views.Add(new ViewHistory { YYMMDD = "190410", Learn = 2, Practice = 1, Quiz = 30 });
            var newViews = views.GroupBy(t => t.YYMMDD.Substring(0, 4))
                .Select(t => new
                {
                    yymm = t.Key,
                    learnSum = t.Select(f => f.Learn).Sum(),
                    practiceSum = t.Select(f => f.Practice).Sum(),
                    quizSum = t.Select(f => f.Quiz).Sum()
                }).ToList();
**Result**
{ yymm = "1905", learnSum = 23, practiceSum = 3, quizSum = 90 },
{ yymm = "1904", learnSum = 2, practiceSum = 1, quizSum = 30 }
