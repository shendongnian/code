c#
IEnumerable<Submission> baseQuery = new List<Submission>()
    {
        new Submission()
            {
                LearningActions = new List<LearningAction>()
                    {
                        //new LearningAction() { ProgressUpdates = null }, // will throw nullRef
                        new LearningAction() { ProgressUpdates = new List<ProgressUpdate>() }, // this is your problem
                    },
            }
    };
int? averageProgress = 100;
baseQuery = baseQuery.Where(
    s => s.LearningActions.SelectMany(la => la.ProgressUpdates)
         .GroupBy(d => d.LearningActionId)
         .Select(a => a.Any() ? new { Max = a.Max(d => d.Progress) } : new { Max = 0 })
         .Average(a => a?.Max) < averageProgress.GetValueOrDefault()); // Here a can be null or empty
Console.WriteLine(string.Join("\n\n", baseQuery));
