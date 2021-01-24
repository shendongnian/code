    var ans = _context.Assessments
                .GroupBy(a => a.SubmissionId)
                .SelectMany(a_sg => a_sg.SelectMany(a => a.AssessmentItems)
                                        .GroupBy(ai => new { ai.RubricItemId, ai.CurrentScore})
                                        .Where(ai_ricsg => ai_ricsg.Count() > 1)
                                        .Select(ai_ricsg => new { ai_ricsg.Key.RubricItemId, DifferentScoreCountPerSubmission = ai_ricsg.Count() })
                )
                .GroupBy(ric => ric.RubricItemId)
                .Select(ric_rig => new { RubricItemId = ric_rig.Key, DifferentScoreCount = ric_rig.Sum(ric => ric.DifferentScoreCountPerSubmission) });
