    var base1 = _context.AssessmentItems
        .Include(ai => ai.RubricItem)
        .Include(ai => ai.Assessment)
        .Where(ai => ai.RubricItem.RubricId == rubricId && ai.Assessment.Submission.ReviewRoundId == reviewRoundId)
        .Select(ai => new {
            ai.Id,
            ai.DateCreated,
            ai.CurrentScore,
            ai.RubricItemId,
            ai.Assessment.SubmissionId,
            ai.Assessment.EvaluatorId
        })
        .GroupBy(ai => ai.RubricItemId);
    var ans1 = base1
                .SelectMany(rig => rig.Select(ai => ai.DateCreated).Distinct().Select(DateCreated => new { RubricItemId = rig.Key, DateCreated, Items = rig.Where(b => b.DateCreated <= DateCreated) }))
                .Select(g => new {
                    g.RubricItemId,
                    DateCreated = g.DateCreated.ToShortDateString(), //.ToString(@"yyyy-MM-dd"),
                    AverageScore = g.Items.Average(ai => ai.CurrentScore),
                    NumberOfStudentsEvaluating = g.Items.Select(ai => ai.EvaluatorId).Distinct().Count(),
                }).ToList();
