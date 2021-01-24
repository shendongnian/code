    decimal average = averageScore.GetValueOrDefault();
    
    baseQuery = baseQuery.Where(s => s.Assessments
        .SelectMany(a => a.AssessmentItems)
        .Where(ai => ai.RubricItemId == rubricItemId)
        .Average(d => d.CurrentScore) > average);
