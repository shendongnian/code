var views = new List<ViewHistory>
{
    new ViewHistory {YYMMDD = "190515", Learn = 1, Practice = 2, Quiz = 3},
    new ViewHistory {YYMMDD = "190514", Learn = 5, Practice = 6, Quiz = 7},
    new ViewHistory {YYMMDD = "190415", Learn = 100, Practice = 110, Quiz = 120},
    new ViewHistory {YYMMDD = "190414", Learn = 150, Practice = 160, Quiz = 170}
};
var monthlyTotals = views.GroupBy(
    v => v.YYMMDD.Substring(0, 4),
    v => v,
    (yearMonth, groupedViews) =>
        new
        {
            YearMonth = yearMonth,
            LearnSum = groupedViews.Sum(view => view.Learn),
            PracticeSum = groupedViews.Sum(view => view.Practice),
            QuizSum = groupedViews.Sum(view => view.Quiz)
        }).ToList();
### Results
**`monthlyTotals`** (copied from Visual Studio Locals window while debugging)
lang-none
monthlyTotals	Count = 2	System.Collections.Generic.List<<>f__AnonymousType0<string, int, int, int>>
    [0]	{ YearMonth = "1905", LearnSum = 6, PracticeSum = 8, QuizSum = 10 } <Anonymous Type>
    [1]	{ YearMonth = "1904", LearnSum = 250, PracticeSum = 270, QuizSum = 290 } <Anonymous Type>
### Rather not use anonymous types?
And, of course, if you prefer not to use an anonymous type, you could define a new class (let's say `MonthlyViewTotals` for example) and instantiate a list of those for your `monthlyTotals` instead like this:
var monthlyTotals = views.GroupBy(
    v => v.YYMMDD.Substring(0, 4),
    v => v,
    (yearMonth, groupedViews) =>
        new MonthlyViewTotals        // <-- no more anonymous types
        {
            YearMonth = yearMonth,
            LearnSum = groupedViews.Sum(view => view.Learn),
            PracticeSum = groupedViews.Sum(view => view.Practice),
            QuizSum = groupedViews.Sum(view => view.Quiz)
        }).ToList();
