var views = new List<ViewHistory>();
            views.Add(new ViewHistory {YYMMDD = "test", Learn = 20, Practice = 1, Quiz = 30});
            views.Add(new ViewHistory { YYMMDD = "test", Learn = 1, Practice = 1, Quiz = 30 });
            views.Add(new ViewHistory { YYMMDD = "test", Learn = 2, Practice = 1, Quiz = 30 });
            views.Add(new ViewHistory { YYMMDD = "test2", Learn = 2, Practice = 1, Quiz = 30 });
            var newViews = views.GroupBy(t => t.YYMMDD)
                .Select(t => new
                {
                    yymmdd = t.Key,
                    learnSum = t.Select(f => f.Learn).Sum(),
                    practiceSum = t.Select(f => f.Practice).Sum(),
                    quizSum = t.Select(f => f.Quiz).Sum()
                }).ToList();
**Result**
{ yymmdd = "test", learnSum = 23, practiceSum = 3, quizSum = 90 },
{ yymmdd = "test2", learnSum = 2, practiceSum = 1, quizSum = 30 }
