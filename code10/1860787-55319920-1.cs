    var groupCount = from feedback in feedbacks
                                 from step in feedback.FeedbackSteps
                                 group step by step.StepNumber into stepsByNumber
                                 select new
                                 {
                                     StepNumber = stepsByNumber.Key,
                                     CountsByStatus = from byStep in stepsByNumber
                                                      group byStep by byStep.AchivmentStatus into byAchivment
                                                      select new { AchivmentStatus = byAchivment.Key, Count = byAchivment.Count() }
                                 };
