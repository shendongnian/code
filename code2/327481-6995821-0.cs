    @(
    Html.Telerik().TreeView()
        .Name("SeniorMetrix")
        .Items(member => {
          foreach (var member1 in members)
                member.Add()
                .Text(member1.FirstName.ToString())
                .SpriteCssClasses("icon-members")
                .Items(occurance =>
                {
                //lets print In-Home Assessments first
                foreach (var inhomeassessment1 in inHomeAssessments)
                  if (inhomeassessment1.MemberID == member1.MemberID)
                  {
                    occurance.Add()
                    .Text("In-Home Assessment #" + inhomeassessment1.InHomeAssessmentID.ToString())
                    .SpriteCssClasses("icon-assessments");
                  }
                //now we print Telephonic Assessments
                foreach (var telephonicassessment1 in telephonicAssessments)
                  if (telephonicassessment1.MemberID == member1.MemberID)
                  {
                    occurance.Add()
                    .Text("Telephonic Assessment #" + telephonicassessment1.TelephonicAssessmentID.ToString())
                    .SpriteCssClasses("icon-phone");
                  }
                //finally, let's print Episodes
                foreach (var episode1 in episodes)
                  if (episode1.MemberID == member1.MemberID)
                  {
                    occurance.Add()
                    .Text("Episode #" + episode1.EpisodeID.ToString())
                    .SpriteCssClasses("icon-episodes")
                    .Items(assessment =>
                      {
                        foreach (var assessment1 in Episodes)
                          if (assessment1.EpisodeID == episode1.EpisodeID)
                          {
                            if (assessment1.AssessmentTypeID == 1)
                            {
                              assessment.Add()
                            .Text("Admission Assessment #" + afeassessment1.AssessmentID.ToString())
                            .SpriteCssClasses("icon-assessment");
                            }
                            if (assessment1.AssessmentTypeID == 2)
                            {
                              assessment.Add()
                            .Text("Interum Assessment #" + assessment1.AssessmentID.ToString())
                            .SpriteCssClasses("icon-assessment");
                            }
                            if (assessment1.AssessmentTypeID == 3)
                            {
                              assessment.Add()
                            .Text("Discharge Assessment #" + assessment1.AssessmentID.ToString())
                            .SpriteCssClasses("icon-assessment");
                            }
                            if (assessment1.AssessmentTypeID == 4)
                            {
                              assessment.Add()
                            .Text("Followup Assessment #" + assessment1.AssessmentID.ToString())
                            .SpriteCssClasses("icon-assessment");
                            }
                          }
                    });
              }});
         }))
